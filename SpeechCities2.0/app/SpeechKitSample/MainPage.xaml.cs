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
        SpeechRecognition speechRec;

        public MainPage()
        {
            InitializeComponent();
            speechRec = new SpeechRecognition();
        }

        private void Button_Tap(object sender, GestureEventArgs e)
        {
            string result = speechRec.SpeechResult();
        }

    }
}