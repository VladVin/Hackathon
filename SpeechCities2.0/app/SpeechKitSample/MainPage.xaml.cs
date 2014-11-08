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
        private Recognizer _recognizer;

        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void Record_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

    }
}