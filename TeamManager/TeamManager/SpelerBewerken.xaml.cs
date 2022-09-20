using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class SpelerBewerken : Page
    {
        Speler speler;
        ObservableCollection<string> competities;
        ObservableCollection<string> teams;

        public SpelerBewerken()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            speler = DataAccess.getSpeler(ManagerTool.IDhuidigeSpeler);
            competities = new ObservableCollection<string>(DataAccess.getCompeties());
            CompetitieCombobox.ItemsSource = competities;
            CompetitieCombobox.SelectedItem = ManagerTool.huidigeCompetitie;
            TeamCombobox.SelectedItem = ManagerTool.huidigTeam; 
        }

        private void TerugButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(InfoSpeler));
        }

        private void BewerkenButton_Click(object sender, RoutedEventArgs e)
        {
            bool inputIsCorrect = true;
            if (speler.nummer == Int32.Parse(InvoerNummer.Text))
            {
                //niets doen              
            }
            else if (DataAccess.IsNummerAlInGebruik(Int32.Parse(InvoerNummer.Text), TeamCombobox.SelectedItem.ToString()))
            {
                NummerIsInGebruik.IsOpen = true;
                inputIsCorrect = false;
            }

            if (String.IsNullOrEmpty(InvoerNaam.Text) || string.IsNullOrEmpty(InvoerLeeftijd.Text) || string.IsNullOrEmpty(InvoerLengte.Text) || string.IsNullOrEmpty(InvoerGewicht.Text) || string.IsNullOrEmpty(Invoerpositie.SelectedItem.ToString()) || string.IsNullOrEmpty(InvoerNummer.Text) || string.IsNullOrEmpty(TeamCombobox.SelectedItem.ToString()))
            {
                VeldenNietIngevuld.IsOpen = true;
                inputIsCorrect = false;
            }

            if (inputIsCorrect) 
            {
                DataAccess.SpelerBewerken(InvoerNaam.Text, InvoerLeeftijd.Text, InvoerLengte.Text, Int32.Parse(InvoerGewicht.Text), Invoerpositie.SelectedItem.ToString(), Int32.Parse(InvoerNummer.Text), TeamCombobox.SelectedItem.ToString(), ManagerTool.IDhuidigeSpeler);
                SpelerToegevoegd.IsOpen = true;
            }
        }

        private void CompetitieCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            teams = new ObservableCollection<string>(DataAccess.GetTeams(CompetitieCombobox.SelectedItem.ToString()));
            TeamCombobox.ItemsSource = teams;
        }
    }
}
