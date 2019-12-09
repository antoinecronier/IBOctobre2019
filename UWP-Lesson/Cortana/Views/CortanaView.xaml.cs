using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_Lesson.Cortana.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class CortanaView : Page
    {
        public CortanaView()
        {
            this.InitializeComponent();
            this.richEditBox1.Document.SetText(Windows.UI.Text.TextSetOptions.None,
                "Hello," +
                "J'espère que vous allez bien." +
                "Il y a des périodes de l'année où j'ai vraiment l'impression d'être mon smartphone.Un genre de smartphone humain...Je sonne tous les matins à la même heure, je tourne à fond toute la journée essayant d'effectuer l'ensemble des tâches de ma todo list, communiquant avec d'autres smartphones comme moi et puis quand vient le soir, mon niveau de batterie approchant du zéro, je me mets en charge en allant dormir pour pouvoir continuer à fonctionner le lendemain." +
                "Peut - être que certains d'entre vous éprouvent ça aussi." +
                "Mais les batteries, ça s'use (ou ça explose ;-)) alors comme c'est les vacances scolaires en ce moment dans ma région, je vais prendre quelques jours la semaine prochaine pour faire un break et passer du temps en famille. Un peu comme si je basculais en mode \"avion\" le temps d'une semaine, mais sans passer par la case aéroport." +
                "En genre d'entre 2 tours personnel finalement ;-)" +
                "Allez, portez - vous bien et à très vite !"
                );
        }

        private void button1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextToSpeech.Instance.PauseEvent -= Instance_PauseEvent;
            TextToSpeech.Instance.PlayEvent -= Instance_PlayEvent;
            TextToSpeech.Instance.ResumeEvent -= Instance_ResumeEvent;
            TextToSpeech.Instance.StopEvent -= Instance_StopEvent;

            TextToSpeech.Instance.PauseEvent += Instance_PauseEvent;
            TextToSpeech.Instance.PlayEvent += Instance_PlayEvent;
            TextToSpeech.Instance.ResumeEvent += Instance_ResumeEvent;
            TextToSpeech.Instance.StopEvent += Instance_StopEvent;

            String text = "";
            this.richEditBox1.Document.GetText(Windows.UI.Text.TextGetOptions.None, out text);
            TextToSpeech.Instance.Play(text);
        }

        private void button2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextToSpeech.Instance.Pause();
        }

        private void button3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextToSpeech.Instance.Resume();
        }

        private void button4_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextToSpeech.Instance.Stop();
        }

        private void button5_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SpeechToText.Instance.Start -= Instance_Start;
            SpeechToText.Instance.HaveResult -= Instance_HaveResult;
            SpeechToText.Instance.Stop -= Instance_Stop;

            SpeechToText.Instance.Start += Instance_Start;
            SpeechToText.Instance.HaveResult += Instance_HaveResult;
            SpeechToText.Instance.Stop += Instance_Stop;

            //SpeechToText.Instance.StartOverlayRecognization();
            SpeechToText.Instance.StartRecognization();
        }

        private void button6_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SpeechToText.Instance.StopRecognization();
        }

        private async void Instance_StopEvent(object sender, EventArgs e)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                    Windows.UI.Core.CoreDispatcherPriority.Normal,
                    () =>
                    {
                        MessageDialog dialog = new MessageDialog("Stop Event");
                        dialog.ShowAsync();
                    });
        }

        private async void Instance_ResumeEvent(object sender, EventArgs e)
        {
            MessageDialog dialog = new MessageDialog("Resume Event");
            await dialog.ShowAsync();
        }

        private async void Instance_PlayEvent(object sender, EventArgs e)
        {
            MessageDialog dialog = new MessageDialog("Play Event");
            await dialog.ShowAsync();
        }

        private async void Instance_PauseEvent(object sender, EventArgs e)
        {
            MessageDialog dialog = new MessageDialog("Pause Event");
            await dialog.ShowAsync();
        }

        private void Instance_Start(object sender, EventArgs e)
        {
        }

        private async void Instance_HaveResult(object sender, SpeechToText.SpeechToTextEventArgs e)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                    Windows.UI.Core.CoreDispatcherPriority.Normal,
                    () =>
                    {
                        this.richEditBox1.Document.SetText(Windows.UI.Text.TextSetOptions.None, e.SpeechResultAll.ToString());
                    });
        }

        private void Instance_Stop(object sender, SpeechToText.SpeechToTextEventArgs e)
        {

        }
    }
}
