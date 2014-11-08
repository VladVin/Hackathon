using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace Yandex.SpeechKit.Demo
{
    class SpeechRecognition
    {
        private Recognizer _recognizer;

        static SpeechRecognition()
        {
            SpeechKitInitializer.Configure("7385ba8e-b595-4411-9404-093bff3e042c");
            SpeechKitInitializer.SetParameter("soundformat", "speex");
        }

        public ObservableCollection<string> Results { get; private set; }

        public SpeechRecognition()
        {
            Results = new ObservableCollection<string>();
        }

        public string SpeechResult()
        {
            StartRecognition();
            return Results[0];
        }

        private void StartRecognition()
        {
            Results.Clear();

            if (_recognizer != null)
            {
                _recognizer.RecognitionDone -= RecognizerRecognitionDone;
                _recognizer.Cancel();
            }

            _recognizer = Recognizer.Create("ru-RU", LanguageModel.General);
            _recognizer.RecognitionDone += RecognizerRecognitionDone;
            _recognizer.Start();
        }

        private void RecognizerRecognitionDone(Recognizer sender, Recognition recognition)
        {
            RecognitionHypothesis[] results = recognition.Results ?? new RecognitionHypothesis[0];
            foreach (RecognitionHypothesis hypothesis in results)
            {
                Results.Add(string.Format("{0:0.00}: {1}", hypothesis.Confidence, hypothesis.Text));
            }
        }
    }
}
