﻿using System;
using Yandex.SpeechKit.UI;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using System.Threading.Tasks;

namespace Yandex.SpeechKit.Demo

{
    /// <summary>
    /// Main application page.
    /// </summary>
    public partial class MainPage
    {
        private CitiesGame Game;
        private CitiesGame.ActionResults actRes;

        public MainPage()
        {
            InitializeComponent();
            Game = new CitiesGame();
            InitializeNewGame();
        }

        private void InitializeNewGame()
        {
            Game.NewGame();
            Score.Text = "Score: " + Game.personScore.ToString();
            CityName.Text = "";
            actRes = CitiesGame.ActionResults.None;
        }

        // Crutch
        private void NormalizeTaps(ref int tCount)
        {
            if (tCount == 0)
            {
                DoAction.Tap += Ellipse_Tap;
            }

            for (int i = 1; i < tCount; ++i)
            {
                DoAction.Tap -= Ellipse_Tap;
            }

            tCount = 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InitializeNewGame();
        }

        private async void Ellipse_Tap(object sender, GestureEventArgs e)
        {
            DoingAction.Opacity = 1.0d;

            actRes = await Game.DoAction();
            
            Score.Text = "Score: " + Game.personScore.ToString();
            CityName.Text = Game.prevCity.ToUpper();
            DoingAction.Opacity = 0.7d;
        }
    }
}