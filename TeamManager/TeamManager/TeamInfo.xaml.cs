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
    public sealed partial class TeamInfo : Page
    {
        public TeamInfo()
        {
            this.InitializeComponent();        
        }
    

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            List<Speler> spelers = DataAccess.GetSpelers(ManagerTool.huidigTeam);
            var query = from item in spelers
                            //items in query groeperen per linie met gebruik van GoupInfoList. 
                        group item by item.linie into g
                        orderby g.Key
                        select new GroupInfoList(g) { Key = g.Key };

            ObservableCollection<GroupInfoList> spelersGroepen = new ObservableCollection<GroupInfoList>(query);
            SpelerCVC.Source = spelersGroepen;

            string coach = DataAccess.GetCoach(ManagerTool.huidigTeam);
            Coach.Items.Add(coach);

        }

        private void SpelerToevoegen_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SpelerToevoegen));
        }

        private void CoachToevoegen_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CoachToevoegen));
        }

        private void Speler_click(object sender, ItemClickEventArgs e)
        {
            Speler speler = (Speler)e.ClickedItem;
            ManagerTool.IDhuidigeSpeler = speler.ID;
            this.Frame.Navigate(typeof(InfoSpeler));
        }

        private void CoachVerwijderen_click(object sender, RoutedEventArgs e)
        {          
            DataAccess.DeleteCoach(DataAccess.GetCoach(ManagerTool.huidigTeam));
        }

        private void SpelerVerwijderen_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SpelerVerwijderen));
        }
    }
}
