﻿

using Sdl.Core.Globalization;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.TranslationMemoryApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiskmoTranslationProvider
{
    public class FileReader : AbstractBilingualContentProcessor
    {
        internal List<Tuple<string,string>> FileTranslations;
        internal List<string> FileNewSegments;
        internal List<TranslationUnit> TmFuzzies;
        private int collectedSentencePairCount;
        private FinetuneBatchTaskSettings settings;
        private FiskmoOptions options;
        IEnumerable<ITranslationProviderLanguageDirection> tmLanguageDirections;

        public FileReader(IEnumerable<ITranslationProviderLanguageDirection> tms, FinetuneBatchTaskSettings settings, int collectedSentencePairCount)
        {
            this.CollectedSentencePairCount = collectedSentencePairCount;
            this.settings = settings;
            this.options = new FiskmoOptions(new Uri(settings.ProviderOptions));
            this.FileTranslations = new List<Tuple<string, string>>();
            this.FileNewSegments = new List<string>();
            this.TmFuzzies = new List<TranslationUnit>();
            this.tmLanguageDirections = tms;
        }

        public int CollectedSentencePairCount { get => collectedSentencePairCount; set => collectedSentencePairCount = value; }

        public override void ProcessParagraphUnit(IParagraphUnit paragraphUnit)
        {
            //If hard limit of fine tuning sentence pair collection has been reached, stop collecting
            if (this.collectedSentencePairCount > FiskmoTpSettings.Default.FinetuningSentencePairsHardLimit)
            {
                return;
            }

            // Check if this paragraph actually contains segments 
            // If not, it is just a structure tag content, which is not processed
            if (paragraphUnit.IsStructure)
            {
                return;
            }

            foreach (ISegmentPair segmentPair in paragraphUnit.SegmentPairs)
            {
                if (segmentPair.Properties.ConfirmationLevel == Sdl.Core.Globalization.ConfirmationLevel.Translated ||
                        segmentPair.Properties.ConfirmationLevel == Sdl.Core.Globalization.ConfirmationLevel.ApprovedTranslation)
                {
                    FileTranslations.Add(new Tuple<string, string>(
                        FiskmoProviderElementVisitor.ExtractSegmentText(segmentPair.Source),
                        FiskmoProviderElementVisitor.ExtractSegmentText(segmentPair.Target)));
                    this.collectedSentencePairCount++;
                }
                else
                {
                    //If segment does not have translation, add it to new strings and look for fuzzies
                    FileNewSegments.Add(FiskmoProviderElementVisitor.ExtractSegmentText(segmentPair.Source));

                    SearchSettings searchSettings = new SearchSettings();
                    searchSettings.Mode = SearchMode.NormalSearch;

                    //If max number of fine-tuning sentences has been reached, restrict the
                    //fuzzy collection to only collect a few high fuzzies / exact matches.
                    //This is to prevent TM searches of taking too much time in case of too many fuzzies
                    if (this.collectedSentencePairCount > this.settings.MaxFinetuningSentences)
                    {
                        searchSettings.MinScore = 95;
                        searchSettings.MaxResults = 5;
                    }
                    else
                    {    
                        searchSettings.MinScore = settings.FuzzyMinPercentage;
                        searchSettings.MaxResults = settings.FuzzyMaxResults;
                    }
                    foreach (var tmLangDir in this.tmLanguageDirections)
                    {
                        var results = tmLangDir.SearchText(searchSettings, segmentPair.Source.ToString());
                        this.TmFuzzies.AddRange(results.Select(x => x.MemoryTranslationUnit));
                        this.collectedSentencePairCount += results.Count;
                    }

                }
            }
        }
    }
}