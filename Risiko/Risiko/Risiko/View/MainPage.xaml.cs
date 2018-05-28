using Xamarin.Forms;

namespace Risiko.View
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		    BindingContext = new ViewModel.MainPageViewModel();
		    NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}
