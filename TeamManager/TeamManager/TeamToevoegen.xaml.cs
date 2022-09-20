using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DataAccessLibrary;





// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TeamManager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TeamToevoegen : Page 
    {
        List<string> competities = new List<string>();

        public TeamToevoegen()
        {
            this.InitializeComponent();            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            competities = DataAccess.getCompeties();
            competities.Sort();
            CompetitieCombobox.ItemsSource = competities;
        }

        private void KlikTeamToevoegenAsync(object sender, RoutedEventArgs e)
        {
            VeldenNietIngevuld.IsOpen = false;
            TeamNaamTeLang.IsOpen = false;
            LandNaamTeLang.IsOpen = false;
            CompetitieNaamTeLang.IsOpen = false;

            bool veldenIngevuld = !(String.IsNullOrEmpty(Teamnaam.Text) | String.IsNullOrEmpty(Land.Text) | CompetitieCombobox.SelectedItem == null);
            bool teamNaamTeLang = Teamnaam.Text.Length > 20;
            bool landNaamTeLang = Land.Text.Length > 20;
            bool competitieNaamTeLang = CompetitieCombobox.Text.Length > 20;

            // controleren of alle velden zijn ingevuld
            if (String.IsNullOrEmpty(Teamnaam.Text) | String.IsNullOrEmpty(Land.Text) | CompetitieCombobox.SelectedItem == null)
            {
                VeldenNietIngevuld.IsOpen = true;
            }

            // controleren of input niet te lang is
            if (Teamnaam.Text.Length > 20)
            {
                TeamNaamTeLang.IsOpen = true;
            }

            if (Land.Text.Length > 20)
            {
                LandNaamTeLang.IsOpen = true;
            }

            if (CompetitieCombobox.Text.Length > 20)
            {
                CompetitieNaamTeLang.IsOpen = true;
            }

            if (veldenIngevuld && !teamNaamTeLang && !landNaamTeLang && !competitieNaamTeLang)
            {
                DataAccessLibrary.DataAccess.AddTeam(Teamnaam.Text, Land.Text, CompetitieCombobox.SelectedItem.ToString());
                TeamToegevoegd.IsOpen = true;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }

        private void Land_Textchanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                               sender.ItemsSource = DataAccess.getLanden();
            }
        }

        private void Land_suggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            Land.Text = args.SelectedItem.ToString();
        }

       
    }
}
