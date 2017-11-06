using RisikoApp.View;
using Xamarin.Forms;

namespace RisikoApp
{
    public partial class App : Application
    {
        private static App Instance;

        public App()
        {
            InitializeComponent();
            Instance = this;
            //MainPage = new NavigationPage(new MainPage());
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static void navigateTo(ContentPage page)
        {
            //the if is needed to provide a back button in the windows app
            if (Device.OS == TargetPlatform.Windows)
            {
                Instance?.MainPage.Navigation.PushAsync(page);
            }
            else
            {
                Instance?.MainPage.Navigation.PushModalAsync(page);
            }
        }
    }
}
