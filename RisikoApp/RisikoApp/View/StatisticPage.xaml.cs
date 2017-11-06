using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RisikoApp.Model;
using RisikoApp.ViewModel;

using Xamarin.Forms;

namespace RisikoApp.View
{
    public partial class StatisticPage : ContentPage
    {
        public StatisticPage(FightStatistic stats)
        {
            InitializeComponent();
            BindingContext = new StatisticPageViewModel(stats, roundsGrid);
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
