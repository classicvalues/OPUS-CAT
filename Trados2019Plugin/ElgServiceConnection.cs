﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpusCatTranslationProvider
{
    internal class ElgServiceConnection
    {
        private IElgCredentials elgCreds;

        internal ElgConnectionStatus Status { get; set; }

        internal enum ElgConnectionStatus
        {
            Ok,
            IncorrectSuccessCode,
            InvalidRefreshToken,
            NoRefreshCode
        }

        public ElgServiceConnection(IElgCredentials elgCreds)
        {
            this.elgCreds = elgCreds;
        }

        internal bool? CheckLanguagePairAvailability(string sourceLangCode, string targetLangCode)
        {
            var response = this.ProcessTranslationRequest("test", sourceLangCode, targetLangCode);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return null;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            else
            {
                return response.IsSuccessful;
            }
        }

        internal string Translate(string source, string sourceLangCode, string targetLangCode)
        {
            var translationResponse = this.ProcessTranslationRequest(source, sourceLangCode, targetLangCode);
            if (translationResponse.IsSuccessful)
            {
                TranslationResponseRoot translationObject = JsonConvert.DeserializeObject<TranslationResponseRoot>(translationResponse.Content);
                return translationObject.response.texts[0].content;
            }
            else
            {
                throw new Exception($"Problem fetching translation from ELG: {translationResponse.StatusCode}");
                //return null;
            }
        }

        internal IRestResponse ProcessTranslationRequest(string source, string sourceLangCode, string targetLangCode)
        {
            if (this.elgCreds.AccessToken == null)
            {
                if (this.elgCreds.RefreshToken != null)
                {
                    this.RefreshAccessToken();
                }
                else
                {
                    this.Status = ElgConnectionStatus.NoRefreshCode;
                }
            }

            IRestResponse response = this.SendTranslationRequest(source, sourceLangCode, targetLangCode);
            
            //If translation request fails, get new access code and retry
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                this.RefreshAccessToken();
                if (this.Status == ElgConnectionStatus.Ok)
                {
                    response = this.SendTranslationRequest(source, sourceLangCode, targetLangCode);
                }
            }
            return response;
        }

        private IRestResponse SendTranslationRequest(string source, string sourceLangCode, string targetLangCode)
        {
            var client = new RestClient("" +
                $"https://live.european-language-grid.eu/execution/processText/opusmt{sourceLangCode}{targetLangCode}");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Bearer {this.elgCreds.AccessToken}");
            request.AddHeader("Content-Type", "text/plain");
            request.AddParameter("text/plain", source + "\n", ParameterType.RequestBody);
            
            IRestResponse response = client.Execute(request);

            //There seem to be bad gateway errors occasionally
            int retryCount = 5;
            while (response.StatusCode == HttpStatusCode.BadGateway && retryCount > 0)
            {
                response = client.Execute(request);
                retryCount--;
            }

            return response;
        }

        private void RefreshAccessToken()
        {
            var client = new RestClient("https://live.european-language-grid.eu/auth/realms/ELG/protocol/openid-connect/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("refresh_token", this.elgCreds.RefreshToken);
            request.AddParameter("grant_type", "refresh_token");
            request.AddParameter("client_id", "elg-oob");
            request.AddParameter("redirect_uri", "urn:ietf:wg:oauth:2.0:oob");
            
            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                this.Status = ElgConnectionStatus.InvalidRefreshToken;
            }
            else
            {
                this.Status = ElgConnectionStatus.Ok;
                RestSharp.Serialization.Json.JsonDeserializer jsonDeserializer = new RestSharp.Serialization.Json.JsonDeserializer();
                var tokenResponse = jsonDeserializer.Deserialize<ElgTokenResponse>(response);
                this.elgCreds.AccessToken = tokenResponse.access_token;
            }
        }

        internal void GetAccessAndRefreshToken(string successCode)
        {
            var client = new RestClient("https://live.european-language-grid.eu/auth/realms/ELG/protocol/openid-connect/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("code", successCode);
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("client_id", "elg-oob");
            request.AddParameter("redirect_uri", "urn:ietf:wg:oauth:2.0:oob");
            //var response = client.Execute<ElgTokenResponse>(request);
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                RestSharp.Serialization.Json.JsonDeserializer jsonDeserializer = new RestSharp.Serialization.Json.JsonDeserializer();
                var tokenResponse = jsonDeserializer.Deserialize<ElgTokenResponse>(response);
                this.Status = ElgConnectionStatus.Ok;
                this.elgCreds.AccessToken = tokenResponse.access_token;
                this.elgCreds.RefreshToken = tokenResponse.refresh_token;
            }
            else
            {
                this.Status = ElgConnectionStatus.IncorrectSuccessCode;
            }

            //return response.Data;
        }

        
    }
}
