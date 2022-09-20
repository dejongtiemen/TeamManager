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
    public sealed partial class CoachToevoegen : Page
    {
        public CoachToevoegen()
        {
            this.InitializeComponent();
        }
        
        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void KlikCoachToevoegenAsync(object sender, RoutedEventArgs e)
        {
            VeldenNietIngevuld.IsOpen = false;
            NaamTeLang.IsOpen = false;
            CoachToegevoegd.IsOpen = false;

            if (string.IsNullOrEmpty(InvoerNaam.Text))
            {
                VeldenNietIngevuld.IsOpen = true;
            }
            else if (InvoerNaam.Text.Length > 20)
            {
                NaamTeLang.IsOpen = true;
            }
            else
            {
                DataAccess.Addcoach(InvoerNaam.Text, InvoerLeeftijd.Text, ManagerTool.huidigTeam);
                CoachToegevoegd.IsOpen = true;
            }

           
        }

        private void Terug_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TeamInfo));
        }
    }
}
