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
using muxc = Microsoft.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TeamManager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SpelerToevoegen : Page
    {
        public SpelerToevoegen()
        {
            this.InitializeComponent();
        }      
        
        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        

        private void KlikSpelerToevoegen(object sender, RoutedEventArgs e)
        {
            // eventueel openstaande infobar dicht doen
            VeldenNietIngevuld.IsOpen = false;
            NummerIsInGebruik.IsOpen = false;
            SpelerToegevoegd.IsOpen = false;
            TeVeelCharacters.IsOpen = false;

            bool ZijnVeldenIngevuld = !(String.IsNullOrEmpty(InvoerNaam.Text) | String.IsNullOrEmpty(InvoerLeeftijd.Text) | String.IsNullOrEmpty(InvoerGewicht.Text) | Invoerpositie.SelectedItem == null | String.IsNullOrEmpty(InvoerNummer.Text));
            bool IsNummerIngevuld = InvoerNummer.Text.Length > 0;
            bool IsNaamLangerDan20 = InvoerNaam.Text.Length > 20;
            bool IsNummerAlInGebruik = false;

            // controleren of alle velden ingevuld zijn
            if (!ZijnVeldenIngevuld)
            {
                VeldenNietIngevuld.IsOpen = true;
            }

            // controleren of het nummer nog vrij is
            if (IsNummerIngevuld)
            {
                IsNummerAlInGebruik = DataAccess.IsNummerAlInGebruik(Int32.Parse(InvoerNummer.Text), ManagerTool.huidigTeam);
                if (IsNummerAlInGebruik)
                {
                    NummerIsInGebruik.IsOpen = true;
                }
            }

            if(IsNaamLangerDan20)
            {
                TeVeelCharacters.IsOpen = true;
            }

            if (IsNummerIngevuld)
            {
                // speler toevoegen als alle input juist is
                if (ZijnVeldenIngevuld && !IsNummerAlInGebruik && !IsNaamLangerDan20)
                {
                    DataAccess.AddSpeler(InvoerNaam.Text, InvoerLeeftijd.Text, InvoerLengte.Text, Int32.Parse(InvoerGewicht.Text), Invoerpositie.SelectedItem.ToString(), Int32.Parse(InvoerNummer.Text), IDgenerator.SpelerIDToewijzen(), ManagerTool.huidigTeam);
                    SpelerToegevoegd.IsOpen = true;
                }
            }
        }

        private void Terug_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TeamInfo));
        }
    }

    
}
