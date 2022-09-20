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
    public sealed partial class Uitslagen : Page
    {
        ObservableCollection<Wedstrijduitslag> uitslagen;       
        List<Doelpunt> doelpunten;
       
        public Uitslagen()
        {
            this.InitializeComponent();       
        }

        private void UitslagToevoegen_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UitslagToevoegen));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            uitslagen = new ObservableCollection<Wedstrijduitslag>(DataAccess.GetWedstrijduitslagen(ManagerTool.huidigTeam));

            // doelpunten per uitslag ophalen uit db
            foreach (Wedstrijduitslag uitslag in uitslagen)
            {
                doelpunten = DataAccess.getDoelpuntenWedstrijd(uitslag.wedstrijdUitslagID);
                foreach (Doelpunt doelpunt in doelpunten)
                {

                    if (doelpunt.team == uitslag.thuisTeam)
                    {
                        uitslag.thuisDoelpuntenList.Add(doelpunt);
                    }
                    if (doelpunt.team == uitslag.uitTeam)
                    {
                        uitslag.uitDoelpuntenList.Add(doelpunt);
                    }
                }
                uitslag.thuisdoelpuntenListToSTring();
                uitslag.uitdoelpuntenListToSTring();
            }
        }

        private void Verwijderen_click(object sender, RoutedEventArgs e)
        {
            UitslagVerwijderd.IsOpen = false;
           var a = uitslagen.Where(u => u.ToString() == UitslagenList.SelectedItem.ToString());
           Wedstrijduitslag uitslag = a.ElementAt(0);
           DataAccess.DeleteWedstrijdUitslag(uitslag.thuisTeam, uitslag.uitTeam, uitslag.scoreThuis, uitslag.scoreUit, uitslag.wedstrijdUitslagID, uitslag.datum);
           uitslagen.Remove(uitslag);
            UitslagVerwijderd.IsOpen = true;
        }

        private void UitslagenList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataTemplate voor geselecteerde items
            foreach (var item in e.AddedItems)
            {
                ListViewItem lvi = (sender as ListView).ContainerFromItem(item) as ListViewItem;
                lvi.ContentTemplate = (DataTemplate)this.Resources["Detail"];
            }
            //DataTemplate voor niet geselecteerde items
            foreach (var item in e.RemovedItems)
            {
                ListViewItem lvi = (sender as ListView).ContainerFromItem(item) as ListViewItem;             
                lvi.ContentTemplate = (DataTemplate)this.Resources["Normal"];
                
            }
               
            
        }
    }
}
