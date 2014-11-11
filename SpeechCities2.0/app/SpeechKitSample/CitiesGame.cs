using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Phone.Speech.Synthesis;
using System.Windows.Input;

namespace Yandex.SpeechKit.Demo
{
    class CitiesGame
    {
        public enum ActionResults {None, Norm, NotCorrect, LastIsMachine, LastIsPerson, GameOver, Mute};
        private String[] Phrases = {"Привет!",
                                       "Твой ход первый. Называй город",
                                       "Я начинаю",
                                       "Ответ неверный",
                                       "Моя очередь",
                                       "Нужно назвать город на букву ",
                                       "Я тебя не слышу. Назови город еще раз",
                                       "Список городов опустел. Игра закончена"
                                   };
        private String[] LikePhrases = {"Ты молодец. Похлопаем", "Умница", "Ты сегодня умненький", "Печеньку тебе", "Хорошо получается"};
        public CitiesGame()
        {
            cities = new Cities();
            rnd = new Random();
            model = new MainViewModel();
            speechRec = new MySpeechRecognition();
        }

        public void NewGame()
        {
            Say(Phrases[0]);
            machineScore = personScore = 0;
            cities.InitializeCitiesSet();
            int val = rnd.Next(0, 2);
            switch(val)
            {
                case 0:
                    action = Actions.Machine;
                    break;
                case 1:
                    action = Actions.Person;
                    break;
            }
            action = Actions.Machine;
            prevCity = "";
            prevChar = '0';
        }

        public async Task<ActionResults> DoAction()
        {
            bool correct = false;
            string city = "";
            ActionResults doActionRes = ActionResults.NotCorrect;
            if (cities.IsEmpty())
            {
                Say(Phrases[7]);
                doActionRes =  ActionResults.GameOver;
            }
            switch(action)
            {
                    // The machine action
                case Actions.Machine:
                    if (prevChar == '0')
                    {
                        Say(Phrases[2]);
                        city = cities.PullRandomCity();
                    }
                    else
                    {
                        Say(Phrases[4]);
                        city = cities.PullRandomCityByFirstChar(prevChar);
                    }
                    Say(city);
                    machineScore++;
                    action = Actions.Person;
                    doActionRes = ActionResults.LastIsMachine;
                    correct = true;
                    break;

                    // The person action
                case Actions.Person:
                    string possibleCity = "";
                    if (prevChar == '0')
                    {
                        Say(Phrases[1]);
                    }

                    possibleCity = await speechRec.GetRecognitedSpeech();
                    if (possibleCity.Length == 0)
                    {
                        Say(Phrases[6]);
                        doActionRes = ActionResults.Mute;
                        break;
                    }
                    if (possibleCity[0] == prevChar || prevChar == '0')
                    {
                        correct = cities.PullCityByName(possibleCity);
                        if (correct)
                        {
                            city = possibleCity;
                            personScore++;
                            action = Actions.Machine;
                            Say(LikePhrases[rnd.Next(0, 4)]);
                            doActionRes = ActionResults.LastIsPerson;
                        }
                        else
                        {
                            Say(Phrases[3]);
                            doActionRes = ActionResults.NotCorrect;
                            break;
                        }
                    }
                    else
                    {
                        Say(Phrases[5] + prevChar);
                        doActionRes = ActionResults.NotCorrect;
                    }
                    break;
            }
            if (correct)
            {
                prevChar = city[city.Length - 1];
                if (prevChar == 'ь' || prevChar == 'ы' || prevChar == 'ъ')
                {
                    prevChar = city[city.Length - 2];
                }
                prevCity = city;
            }
            else
            {
                doActionRes = ActionResults.NotCorrect;
            }

            return doActionRes;
        }

        public async void Say(string str)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();

            // Query for a voice that speaks French.
            IEnumerable<VoiceInformation> russianVoices = from voice in InstalledVoices.All
                                                         where voice.Language == "ru-RU"
                                                         select voice;

            // Set the voice as identified by the query.
            if (russianVoices.Count() > 0)
            {
                synth.SetVoice(russianVoices.ElementAt(0));
                await synth.SpeakTextAsync(str);
            }
        }

        private MainViewModel model;
        private Random rnd;
        private MySpeechRecognition speechRec;
        enum Actions {Person, Machine};
        private Actions action;
        private char prevChar;
        public string prevCity {get; private set;}
        public Cities cities;
        public int machineScore {get; private set;}
        public int personScore {get; private set;}
    }
}
