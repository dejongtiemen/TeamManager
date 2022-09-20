using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TeamManager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CompetitieToevoegen : Page
    {
        public CompetitieToevoegen()
        {
            this.InitializeComponent();
        }

        private void Toevoegen_Click(object sender, RoutedEventArgs e)
        {
            VeldenNietIngevuld.IsOpen = false;
            CompetitieBestaatAl.IsOpen = false;
            CompetitieToegevoegd.IsOpen = false;
            CompetitieNaamTeLang.IsOpen = false;
            List<string> competities = DataAccess.getCompeties();
            foreach(string competitie in competities)
            {
                competitie.ToLower();
            }

            bool veldenCorrectIngevuld = true;
            if (competities.Contains(CompetitieTextBox.Text.ToLower()))
            {
                CompetitieBestaatAl.IsOpen = true;
                veldenCorrectIngevuld = false;
            }

            if (string.IsNullOrEmpty(CompetitieTextBox.Text))
            {
                VeldenNietIngevuld.IsOpen = true;
                veldenCorrectIngevuld = false;
            }

            if (CompetitieTextBox.Text.Length > 20)
            {
                CompetitieNaamTeLang.IsOpen = true;
                veldenCorrectIngevuld = false;
            }

            if(veldenCorrectIngevuld)
            {
                DataAccess.AddCompetitie(CompetitieTextBox.Text);
                CompetitieToegevoegd.IsOpen = true;
            }

        }

        private void Terug_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void BackButton_click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }
    }
}
