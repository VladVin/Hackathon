using System;
using Yandex.SpeechKit.UI;
using System.Windows;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Yandex.SpeechKit.Demo

{
    /// <summary>
    /// Main application page.
    /// </summary>
    public partial class MainPage
    {
        private SpeechRecognition speechRec;
        private CitiesGame Game;

        public MainPage()
        {
            InitializeComponent();
            speechRec = new SpeechRecognition();
            Game = new CitiesGame();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Game.NewGame();
            RecognizerView.StartRecognition("ru-RU", LanguageModel.General);
        }
        #region overrides
        
        protected override void OnNavigatedTo(NavigationEventArgs args)
        {
            //RecognizerView.StartRecognition("ru-RU", LanguageModel.General);

            base.OnNavigatedTo(args);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs args)
        {
            RecognizerView.CancelRecognition();

            base.OnNavigatedFrom(args);
        }

        #endregion

        private void RecognizerViewFinished(object sender, RecognitionFinishedEventArgs args)
        {
            string result = args.Result;
            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(result);
            }

        }

        private void Ellipse_Tap(object sender, GestureEventArgs e)
        {
            RecognizerView.StartRecognition("ru-RU", LanguageModel.General);
        }
    }
}