using DataAccessLibrary;
using Microsoft.Toolkit.Uwp.UI.Controls;
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
    public sealed partial class Stand : Page
    {
        List<TeamStatistieken> stand;
        public Stand()
        {
            this.InitializeComponent();           
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            List<TeamStatistieken> statistieken = DataAccess.GetStandCompetitie(ManagerTool.huidigTeam);
            //statistiekn sorteren op punten en doelsaldo
            stand = new List<TeamStatistieken>();
            stand = statistieken.OrderByDescending(team => team.punten).ThenByDescending(team => team.doelsaldo).ToList();
            int positie = 1;

            foreach (TeamStatistieken team in stand)
            {
                team.positie = positie++;
                StandList.Items.Add(team);
            }

            DataGrid dataGrid1 = new DataGrid();

        }


    }
}