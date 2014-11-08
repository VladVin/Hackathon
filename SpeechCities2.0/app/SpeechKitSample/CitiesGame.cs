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
        private String[] Phrases = {"Привет хакатон, я умею говорить! Я самый лучший соперник.", "Твой ход первый. Называй город", "Я начинаю",
                                       "Ответ неверный", "Моя очередь", "Нужно назвать город на букву", "Я тебя не слышу. Назови город еще раз"};
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
            prevCity = "null";
            prevChar = '0';
        }

        public async void DoAction()
        {
            string city = "";
            switch(action)
            {
                    // The machine action
                case Actions.Machine:
                    if (prevChar == '0')
                    {
                        Say(Phrases[2]);
                        city = cities.citiesSet.ElementAt(rnd.Next(0, cities.citiesSet.Count - 1));
                    }
                    else
                    {
                        Say(Phrases[4]);
                        city = cities.findRandomCityByFirstChar(prevChar);
                    }
                    Say(city);
                    machineScore++;
                    action = Actions.Person;
                    break;

                    // The person action
                case Actions.Person:
                    string possibleCity;
                    bool correct = false;
                    if (prevChar == '0')
                    {
                        Say(Phrases[1]);
                    }

                    possibleCity = await speechRec.GetRecognitedSpeech();
                    if (possibleCity == null)
                    {
                        Say(Phrases[6]);
                        break;
                    }
                    if (possibleCity[0] == prevChar || prevChar != '0')
                    {
                        correct = cities.PullCityByName(possibleCity);
                    }
                    else
                    {
                        Say(Phrases[5]);
                    }
                    if (correct)
                    {
                        city = possibleCity;
                        personScore++;
                        action = Actions.Machine;
                        Say(LikePhrases[rnd.Next(0, 4)]);
                    }
                    else
                    {
                        Say(Phrases[3]);
                    }
                    break;
            }
            prevChar = city[city.Length - 1];
            if (prevChar == 'ь' || prevChar == 'ы' || prevChar == 'ъ')
            {
                prevChar = city[city.Length - 2];
            }
            prevCity = city;
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
        public string prevCity;
        public Cities cities;
        public int machineScore, personScore;
    }
}
