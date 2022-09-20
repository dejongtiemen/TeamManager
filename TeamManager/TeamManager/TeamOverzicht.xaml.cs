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
    public sealed partial class TeamOverzicht : Page
    {
      
        public TeamOverzicht()
        {
            this.InitializeComponent();
        }

        private void NavigationViewControl_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;
            ManagerTool.geselecteerdItemTeamInfo = item.Tag.ToString();


            switch (item.Tag.ToString())
            {
                case "Team":
                    ContentFrame.Navigate(typeof(TeamInfo));
                    break;
                case "Stand":
                    ContentFrame.Navigate(typeof(Stand));
                    break;
                case "Uitslagen":
                    ContentFrame.Navigate(typeof(Uitslagen));
                    break;
                case "Topscorers":
                    ContentFrame.Navigate(typeof(Topscorers));
                    break;
            }
        }

        private void NavigationViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(TeamInfo));
        }

        private void NavigationViewControl_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        
    }
}
