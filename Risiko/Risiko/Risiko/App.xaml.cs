using System;
using Risiko.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Risiko
{
	public partial class App : Application
	{
	    private static App _instance;

        public App ()
		{
			InitializeComponent();
		    _instance = this;
		    //MainPage = new NavigationPage(new MainPage());
            MainPage = new MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

	    public static void navigateTo(ContentPage page)
	    {
	        //the if is needed to provide a back button in the windows app
	        if (Device.RuntimePlatform == Device.UWP)
	        {
	            _instance?.MainPage.Navigation.PushAsync(page);
	        }
	        else
	        {
	            _instance?.MainPage.Navigation.PushModalAsync(page);
	        }
	    }
    }
}
