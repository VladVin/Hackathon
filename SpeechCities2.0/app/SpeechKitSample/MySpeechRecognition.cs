using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using Yandex.SpeechKit;
using Yandex.SpeechKit.UI;
using System.Windows.Threading;

namespace Yandex.SpeechKit.Demo
{
    public class MySpeechRecognition
    {
        RecognizerView recView;
        private string result;
        public enum States { Canceled, Finished, Process };
        public States status {get; private set;}
        DispatcherTimer dt;

        public MySpeechRecognition()
        {
            SpeechKitInitializer.Configure("7385ba8e-b595-4411-9404-093bff3e042c");
            SpeechKitInitializer.SetParameter("soundformat", "speex");
            recView = new RecognizerView();
            recView.Finished += recView_Finished;
            dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dt.Tick += dt_Tick;
        }

        void dt_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetRecognitedSpeech()
        {
            recView.StartRecognition("ru-RU", LanguageModel.Maps);

            status = States.Process;
            int time = 0;
            await Task.Run(async delegate
            {
                do
                {
                    await Task.Delay(100);
                    //time += 100;
                    //if (time > 10000)
                    //{
                    //    recView.CancelRecognition();
                    //    status = States.Canceled;
                    //}
                } while ((status != States.Finished) && (status != States.Canceled));
            });
            
            return result.ToLower();
        }

        private void recView_Finished(object sender, UI.RecognitionFinishedEventArgs e)
        {
            result = e.Result;
            status = States.Finished;
        }
    }
}
