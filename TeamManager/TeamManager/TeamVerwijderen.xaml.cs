using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TeamManager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TeamVerwijderen : Page
    {
        public List<string> teams;
        
        public TeamVerwijderen()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            teams = DataAccess.GetTeams();
        }

        private async void TeamVerwijderen_clickAsync(object sender, RoutedEventArgs e)
        {
            ContentDialogResult result = await teamVerwijderenContentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                //alle spelers uit het team verwijderen
                List<Speler> spelers = DataAccess.GetSpelers(TeamsCbbx.SelectionBoxItem.ToString());
                foreach (Speler speler in spelers)
                {
                    DataAccess.DeleteSpeler(speler.ID.ToString());
                }
                DataAccess.DeleteTeam(TeamsCbbx.SelectionBoxItem.ToString());              
                teams.Remove(TeamsCbbx.SelectionBoxItem.ToString());
                TeamVerwijderdInfoBar.IsOpen = true;
            }
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }

        
    }
}
