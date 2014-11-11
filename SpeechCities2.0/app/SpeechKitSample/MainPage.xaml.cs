using System;
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

        public MainPage()
        {
            InitializeComponent();
            Game = new CitiesGame();
            Game.NewGame();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Game.NewGame();
            Score.Text = "Score: " + Game.personScore.ToString();
            CityName.Text = "";
        }

        private async void Ellipse_Tap(object sender, GestureEventArgs e)
        {
            DoingAction.Opacity = 1.0d;
            CitiesGame.ActionResults actRes = CitiesGame.ActionResults.NotCorrect;
            actRes = await Game.DoAction();
            if (actRes == CitiesGame.ActionResults.LastIsPerson)
            {
                Score.Text = "Score: " + Game.personScore.ToString();
                await Game.DoAction();
            }
            CityName.Text = Game.prevCity;
            DoingAction.Opacity = 0.7d;
        }
    }
}