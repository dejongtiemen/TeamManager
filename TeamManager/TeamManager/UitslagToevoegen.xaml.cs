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
    public sealed partial class UitslagToevoegen : Page
    {
        ObservableCollection<string> teamsUit = new ObservableCollection<string>();
        ObservableCollection<string> teamsThuis = new ObservableCollection<string>();
        ObservableCollection<Speler> spelers = new ObservableCollection<Speler>();       
        ObservableCollection<Doelpunt> doelpuntenmakersUit= new ObservableCollection<Doelpunt>();
        ObservableCollection<Doelpunt> doelpuntenmakersThuis = new ObservableCollection<Doelpunt>();
        ObservableCollection<string> geselecteerdeTeams = new ObservableCollection<string>();
        string geselecteerdThuisTeam;
        string geselecteerdUitTeam;

        public UitslagToevoegen()
        {
            this.InitializeComponent();
            this.Datepicker.Date = DateTime.Now;
        }

        private void UislagToevoegen_click(object sender, RoutedEventArgs e)
        {
            VeldenNietIngevuld.IsOpen = false;
            ScoreGelijkAanDoelputentenmakers.IsOpen = false;
            UitslagToegevoegd.IsOpen = false;

            //controleren of alle velden zijn ingevuld
            if (InvoerThuisTeam.SelectedItem == null | InvoerUitTeam.SelectedItem == null | Datepicker.Date == null)
            {
                VeldenNietIngevuld.IsOpen = true;
            }
            else
            {
                //controleren of de score overeenkomt met het aantal doelputenmakers
                if (Int32.Parse(InvoerThuisScore.Text) >  DoelpuntenmakersLijstThuis.Items.Count)
                {
                    ScoreGelijkAanDoelputentenmakers.IsOpen = true;
                }
                

                if (Int32.Parse(InvoerUitScore.Text) > 0 && DoelpuntenmakersLijstUit.Items == null)
                {
                    ScoreGelijkAanDoelputentenmakers.IsOpen = true;
                }
                

                //als alle input juist is uitslag en doelpunten toevoegen aan db
                if (!(InvoerThuisTeam.SelectedItem == null | InvoerUitTeam.SelectedItem == null | Datepicker.Date == null) && !(Int32.Parse(InvoerThuisScore.Text) > DoelpuntenmakersLijstThuis.Items.Count) && !(Int32.Parse(InvoerUitScore.Text) > DoelpuntenmakersLijstUit.Items.Count))
                {
                    int wedstrijdID = IDgenerator.WedstrijduitslagIDToewijzen();
                    DataAccess.AddWedstrijdUitslag(InvoerThuisTeam.SelectedItem.ToString(), InvoerUitTeam.SelectedItem.ToString(), Int32.Parse(InvoerThuisScore.Text), Int32.Parse(InvoerUitScore.Text), wedstrijdID, Datepicker.Date.ToString("dd/MM/yyyy"));

                    foreach (Doelpunt doelpunt in doelpuntenmakersThuis)
                    {
                        Speler speler = DataAccess.getSpeler(doelpunt.IDspeler);
                        DataAccess.AddDoelpunt(speler.ID.ToString(), speler.naam, doelpunt.minuut.ToString(), wedstrijdID.ToString(), InvoerThuisTeam.SelectedItem.ToString());
                    }

                    foreach (Doelpunt doelpunt in doelpuntenmakersUit)
                    {
                        Speler speler = DataAccess.getSpeler(doelpunt.IDspeler);
                        DataAccess.AddDoelpunt(speler.ID.ToString(), speler.naam, doelpunt.minuut.ToString(), wedstrijdID.ToString(), InvoerUitTeam.SelectedItem.ToString());
                    }
                    UitslagToegevoegd.IsOpen = true;
                }
            }
        }

        private void Terug_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Uitslagen));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            teamsThuis = new ObservableCollection<string>(DataAccess.GetTeams(ManagerTool.huidigeCompetitie));
            teamsThuis = new ObservableCollection<string>(teamsThuis.OrderBy(i => i));
            teamsUit = new ObservableCollection<string>(DataAccess.GetTeams(ManagerTool.huidigeCompetitie));
            teamsUit = new ObservableCollection<string>(teamsUit.OrderBy(i => i));
            DoelpuntenmakersLijstThuis.ItemsSource = doelpuntenmakersThuis;
            DoelpuntenmakersLijstUit.ItemsSource = doelpuntenmakersUit;
            TeamDoelpuntmaker.ItemsSource = geselecteerdeTeams;
        }

        private void InvoerUitTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            if(InvoerUitTeam.SelectedItem != null)
            {
                geselecteerdUitTeam = InvoerUitTeam.SelectedItem.ToString();
            } 
            
            //geselecteerd uitteam toevoegen aan geselecteerde teams. thuisteam ook toevoegen indien geselecteerd
            geselecteerdeTeams = new ObservableCollection<string>();
            TeamDoelpuntmaker.ItemsSource = geselecteerdeTeams;
            geselecteerdeTeams.Add(geselecteerdUitTeam);
            
            if (InvoerThuisTeam.SelectedItem != null)
            {
                geselecteerdeTeams.Add(geselecteerdThuisTeam);
            }
            spelers.Clear();

            //geselecteerde uitteam uit lijst van thuisteams halen en thuisteams sorteren(zodat niet twee dezelfde teams kunnen worden geselecteerd)            
            List<string> list = DataAccess.GetTeams(ManagerTool.huidigeCompetitie);
            list.Sort();

            for (int i = 0; i < list.Count; i++)
            {
                if (!teamsThuis.Contains(list.ElementAt(i)))
                    teamsThuis.Insert(i, list.ElementAt(i));
            }

            teamsThuis.Remove(geselecteerdUitTeam);

        }

        private void InvoerThuisTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InvoerThuisTeam.SelectedItem != null)
            {
                geselecteerdThuisTeam = InvoerThuisTeam.SelectedItem.ToString();
            }

            //geselecteerd thuisteam toevoegen aan geselecteerde teams. uitteam ook toevoegen indien geselecteerd
            geselecteerdeTeams = new ObservableCollection<string>();
            TeamDoelpuntmaker.ItemsSource = geselecteerdeTeams;          
            geselecteerdeTeams.Add(geselecteerdThuisTeam);
            
            if (InvoerUitTeam.SelectedItem != null)
            {
                geselecteerdeTeams.Add(geselecteerdUitTeam);
            }
            spelers.Clear();

            //geselecteerde thuisteam uit lijst  van uitteams halen en uitteams sorteren, zodat niet 2 dezelfde teams worden geselecteerd
            List<string> list = DataAccess.GetTeams(ManagerTool.huidigeCompetitie);
            list.Sort();
           

            for(int i = 0; i < list.Count; i++ )
            {
                if(!teamsUit.Contains(list.ElementAt(i)))
                teamsUit.Insert(i, list.ElementAt(i));               
            }
                     
            teamsUit.Remove(geselecteerdThuisTeam);

        }

        private void DoelputenMakerToevoegen_click(object sender, RoutedEventArgs e)
        {
            //toegevoegde doelpunten moeten even veel zijn al de opgegeven score
            if(Int32.Parse(InvoerThuisScore.Text) > doelpuntenmakersThuis.Count)
            {
                //doelpuntenmaker toevoegen aan de juiste listview
                if (InvoerThuisTeam.SelectedItem.ToString() == TeamDoelpuntmaker.SelectedItem.ToString())
                {
                    Speler speler = (Speler)Doelpuntenmaker.SelectedItem;
                    doelpuntenmakersThuis.Add(new Doelpunt { speler = Doelpuntenmaker.SelectedItem.ToString(), minuut = Int32.Parse(Minuut.Text), IDspeler = speler.ID});
                }
            }

            //toegevoegde doelpunten moeten even veel zijn al de opgegeven score
            if (int.Parse(InvoerUitScore.Text) > doelpuntenmakersUit.Count)
            {
                //doelpuntenmaker toevoegen aan de juiste listview
                if (InvoerUitTeam.SelectedItem.ToString() == TeamDoelpuntmaker.SelectedItem.ToString())
                {
                    Speler speler = (Speler)Doelpuntenmaker.SelectedItem;
                    doelpuntenmakersUit.Add(new Doelpunt { speler = Doelpuntenmaker.SelectedItem.ToString(), minuut = Int32.Parse(Minuut.Text), IDspeler = speler.ID });
                }
            }
            
        }

        private void TeamDoelpuntenmaker_selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TeamDoelpuntmaker.SelectedItem != null) 
            {
                spelers = new ObservableCollection<Speler>(DataAccess.GetSpelers(TeamDoelpuntmaker.SelectedItem.ToString()));
                Doelpuntenmaker.ItemsSource = spelers; 
            }
        }

        private void DoelpuntenmakerThuisVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            if (DoelpuntenmakersLijstThuis.SelectedItem != null)
            {
                for (int i = 0; i < doelpuntenmakersThuis.Count; i++)
                {              
                    if (doelpuntenmakersThuis.ElementAt(i).ToString() == DoelpuntenmakersLijstThuis.SelectedItem.ToString())
                    {
                        doelpuntenmakersThuis.Remove(doelpuntenmakersThuis.ElementAt(i));
                    }
                }
            }
        }

        private void DoelpuntenmakerUitVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            if (DoelpuntenmakersLijstUit.SelectedItem != null)
            {
                for (int i = 0; i < doelpuntenmakersUit.Count; i++)
                {
                    if (doelpuntenmakersUit.ElementAt(i).ToString() == DoelpuntenmakersLijstUit.SelectedItems.ToString())
                    {
                        doelpuntenmakersUit.Remove(doelpuntenmakersUit.ElementAt(i));
                    }
                }
            }
        }
    }
}
