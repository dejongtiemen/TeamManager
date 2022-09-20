using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class InfoSpeler : Page
    {
        public InfoSpeler()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Speler speler = DataAccess.getSpeler(ManagerTool.IDhuidigeSpeler);
            List<Doelpunt> doelpunten = DataAccess.getDoelpuntenSpeler(speler.ID);
            Naam.Text = speler.naam;
            Leeftijd.Text = speler.leeftijd.ToString();
            Lengte.Text = speler.lengte.ToString();
            gewicht.Text = speler.gewicht.ToString();
            Positie.Text = speler.positie;
            Nummer.Text = speler.nummer.ToString();
            Doelpunten.Text = doelpunten.Count.ToString();
        }

        private void TerugButton_Click(object sender, RoutedEventArgs e)
        {
            if (ManagerTool.geselecteerdItemTeamInfo == "Topscorers")
            {
                this.Frame.Navigate(typeof(Topscorers));
            }
            else
            {
                this.Frame.Navigate(typeof(TeamInfo));
            }
        }

        private void Bewerken_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SpelerBewerken));
        }
    }
}
