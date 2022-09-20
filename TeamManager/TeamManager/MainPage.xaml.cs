using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;
using Windows.Security.Cryptography.Certificates;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using DataAccessLibrary;
using TeamManager.Classes;
using Windows.UI.ViewManagement;
using System.Collections.ObjectModel;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TeamManager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page

    {
        ObservableCollection<string> competities;

        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }



        private void Naar_Team_Toevoegen(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TeamToevoegen));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            List<string> CompetitiesL = DataAccess.getCompeties();
            CompetitiesL.Sort();
            competities = new ObservableCollection<string>(CompetitiesL);
            
        }

        private void Team_ItemClick(object sender, ItemClickEventArgs e)
        {
            ManagerTool.huidigTeam = e.ClickedItem.ToString();
            ManagerTool.huidigeCompetitie = CompetitiesCbbx.SelectedItem.ToString();
            this.Frame.Navigate(typeof(TeamOverzicht));
        }

        private void NaarTeamVerwijderen_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TeamVerwijderen));
        }

        private void Competitie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Teamselectie.Items.Clear();
            if (CompetitiesCbbx.SelectedItem != null)
            {
                List<string> teams = DataAccess.GetTeams(CompetitiesCbbx.SelectedItem.ToString());
                teams.Sort();
                foreach (string team in teams)
                {
                    Teamselectie.Items.Add(team);
                }
            }
        }

        private async void CompetitieVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            CompetitieVerwijderdInfoBar.IsOpen = false;
            ContentDialogResult result = await competitieVerwijderenContentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                DataAccess.DeleteCompetitie(CompetitiesCbbx.SelectedItem.ToString());
                CompetitieVerwijderdInfoBar.IsOpen = true;
                competities.Remove(CompetitiesCbbx.SelectedItem.ToString());
            }
        }

        private void CompetitieToevoegen_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CompetitieToevoegen));
        }
    }
}
 