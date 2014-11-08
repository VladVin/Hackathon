using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

namespace Yandex.SpeechKit.Demo
{
    class CitiesGame
    {
        CitiesGame()
        {
            cities = new Cities();
            rnd = new Random();
            model = new MainViewModel();
        }

        public void NewGame()
        {
            machineScore = personScore = 0;
            cities.InitializeCitiesSet();
            action = (Actions)rnd.Next(0, 1);
            prevCity = "null";
            prevChar = '0';
        }

        public void DoAction()
        {
            string city = "";
            switch(action)
            {
                case Actions.Machine:
                    if (prevChar == '0')
                    {
                        city = cities.citiesSet.ElementAt(rnd.Next(0, cities.citiesSet.Count - 1));
                    }
                    else
                    {
                        city = cities.findRandomCityByFirstChar(prevChar);
                    }
                    machineScore++;
                    action = Actions.Person;
                    break;
                case Actions.Person:
                    if (prevChar == '0')
                    {
                        Say("Твой ход первый. Называй город");

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

        //public string SpeechRecognition()
        //{
            
        //}

        public async void Say(string str)
        {

        }

        private MainViewModel model;
        private Random rnd;
        enum Actions {Person, Machine};
        private Actions action;
        private char prevChar;
        public string prevCity;
        public Cities cities;
        public int machineScore, personScore;
    }
}
