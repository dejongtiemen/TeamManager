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
    public sealed partial class Topscorers : Page
    {
        List<Speler> topscorers;
        public Topscorers()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            topscorers = DataAccess.GetDoelpuntenmakersCompetitie(ManagerTool.huidigeCompetitie);
            foreach (Speler speler in topscorers)
            {
                speler.doelpunten = DataAccess.getDoelpuntenSpeler(speler.ID);
                speler.BerekenAantalDoelpunten();
            }

            topscorers = topscorers.OrderByDescending(s => s.aantalDoelpunten).ToList();

            TopscorersListView.ItemsSource = topscorers;
        }

        private void TopscorersListview_ItemClick(object sender, ItemClickEventArgs e)
        {
            Speler speler = (Speler)e.ClickedItem;
            ManagerTool.IDhuidigeSpeler = speler.ID;
            this.Frame.Navigate(typeof(InfoSpeler));
        }
    }
}
