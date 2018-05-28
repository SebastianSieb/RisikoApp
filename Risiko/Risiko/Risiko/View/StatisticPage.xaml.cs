using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Risiko.Model;
using Risiko.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Risiko.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StatisticPage : ContentPage
	{
		public StatisticPage (FightStatistic stats)
		{
			InitializeComponent ();
		    BindingContext = new StatisticPageViewModel(stats, roundsGrid);
		    NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}