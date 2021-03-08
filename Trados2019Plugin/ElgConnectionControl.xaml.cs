﻿using Sdl.LanguagePlatform.TranslationMemoryApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OpusCatTranslationProvider
{
    /// <summary>
    /// OPUS models available through ELG can also be used to generate translation, but
    /// this requires registration on the ELG website. 
    /// </summary>
    public partial class ElgConnectionControl : UserControl, INotifyPropertyChanged
    {
        private ElgServiceConnection elgConnection;
        private string connectionStatus;
        private OpusCatOptions options;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string ConnectionStatus
        {
            get => connectionStatus;
            set
            {
                connectionStatus = value;
                NotifyPropertyChanged();
            }
        }

        public List<string> LanguagePairs { get; internal set; }

        public ElgConnectionControl()
        {
            InitializeComponent();
            this.DataContextChanged += ConnectionControl_DataContextChanged;

            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                Dispatcher.BeginInvoke(new Action(CheckLanguagePairs), System.Windows.Threading.DispatcherPriority.ContextIdle);
            }
        }

        private void CheckLanguagePairs()
        {
            
        }

        private void ConnectionControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is IHasOpusCatOptions)
            {

                this.options = ((IHasOpusCatOptions)e.NewValue).Options;
                PropertyChanged(this, new PropertyChangedEventArgs(null));
                var credStore = ((OpusCatOptionControl)this.DataContext).CredentialStore;
                var elgCreds = new TradosElgCredentialWrapper(credStore);
                this.elgConnection = new ElgServiceConnection(elgCreds);
            }
        }
        
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
        
        private void ConfirmCode_Click(object sender, RoutedEventArgs e)
        {
            var enteredCode = this.ElgSuccessCodeBox.Text;
            if (!String.IsNullOrWhiteSpace(enteredCode))
            {
                this.elgConnection.GetAccessAndRefreshToken(enteredCode);
            }
        }

    }


}
