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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Game.NewGame();
        }
        
        private void Ellipse_Tap(object sender, GestureEventArgs e)
        {
            DoingAction.Fill = new SolidColorBrush(Colors.Green);
            Game.DoAction();
            DoingAction.Fill = new SolidColorBrush(Colors.White);
        }
    }
}