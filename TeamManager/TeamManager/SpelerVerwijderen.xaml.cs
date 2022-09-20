using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TeamManager.Classes;
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
    public sealed partial class SpelerVerwijderen : Page
    {
        ObservableCollection<Speler> spelers;
        public SpelerVerwijderen()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            spelers = new ObservableCollection<Speler>(DataAccess.GetSpelers(ManagerTool.huidigTeam));
        }

        private async void SpelerVerwijderen_clickAsync(object sender, RoutedEventArgs e)
        {
            ContentDialogResult result = await spelerVerwijderenContentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                Speler speler = (Speler)SpelersCbbx.SelectedItem;
                DataAccess.DeleteSpeler(speler.ID.ToString());
                spelers.Remove(speler);
                SpelerVerwijderdInfoBar.IsOpen = true;
            }
           
        }

        private void Terug_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TeamInfo));
        }

        private void SpelersCbbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SpelerVerwijderdInfoBar.IsOpen = false;
        }

        
    }
}
