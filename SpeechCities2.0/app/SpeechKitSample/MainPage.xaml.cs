using System;
using Yandex.SpeechKit.UI;
using System.Windows;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Yandex.SpeechKit.Demo

{
    /// <summary>
    /// Main application page.
    /// </summary>
    public partial class MainPage
    {
        private Recognizer _recognizer;
        public ObservableCollection<string> Results { get; private set; }

        public MainPage()
        {
            InitializeComponent();
            SpeechKitInitializer.Configure("7385ba8e-b595-4411-9404-093bff3e042c");
            SpeechKitInitializer.SetParameter("soundformat", "speex");
            Results = new ObservableCollection<string>();
        }

        bool RecStarted = false;
        
        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!RecStarted)
            {
                Results.Clear();

                if (_recognizer != null)
                {
                    _recognizer.RecognitionDone -= RecognizerRecognitionDone;
                    _recognizer.RecognitionError -= RecognizerRecognitionError;
                    _recognizer.RecordingStarted -= RecognizerRecordingStarted;
                    _recognizer.RecordingFinished -= RecognizerRecordingFinished;
                    _recognizer.PowerUpdated -= RecognizerPowerUpdated;
                    _recognizer.Cancel();
                }

                _recognizer = Recognizer.Create("ru-RU", LanguageModel.General);
                _recognizer.RecognitionDone += RecognizerRecognitionDone;
                _recognizer.RecognitionError += RecognizerRecognitionError;
                _recognizer.RecordingStarted += RecognizerRecordingStarted;
                _recognizer.RecordingFinished += RecognizerRecordingFinished;
                _recognizer.PowerUpdated += RecognizerPowerUpdated;
                _recognizer.Start();

                RecStarted = true;
            }
            else
            {
                if (_recognizer != null)
                {
                    _recognizer.FinishRecording();
                }
                RecStarted = false;
            }
        }

        private void RecognizerRecognitionDone(Recognizer sender, Recognition recognition)
        {
            RecognitionHypothesis[] results = recognition.Results ?? new RecognitionHypothesis[0];

            BeginInvoke(() =>
            {
                foreach (RecognitionHypothesis hypothesis in results)
                {
                    Results.Add(string.Format("{0:0.00}: {1}", hypothesis.Confidence, hypothesis.Text));
                }
            });
        }

        private void RecognizerRecognitionError(Recognizer sender, Error error)
        {
        }

        private void RecognizerRecordingStarted(Recognizer sender)
        {
        }

        private void RecognizerRecordingFinished(Recognizer sender)
        {
            if (!string.IsNullOrEmpty(Results[0]))
            {
                MessageBox.Show(Results[0]);
            }
        }

        private void RecognizerPowerUpdated(Recognizer sender, float value)
        {
        }

        private static void BeginInvoke(Action action)
        {
            Deployment.Current.Dispatcher.BeginInvoke(action);
        }
    }
}