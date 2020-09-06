using System;
using Xamarin.Forms;

namespace com.on.relax.your.eyes.xam
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var skipHelloKey = nameof(Settings.SkipHello);
            if (Current.Properties.ContainsKey(skipHelloKey))
                Settings.SkipHello = (bool)Current.Properties[skipHelloKey];

            MainPage = new NavigationPage(new WorkPage());

            if (!Settings.SkipHello)
            {
                Action tapped = () =>
                {
                    MainPage.Navigation.PopAsync();
                    Settings.SkipHello = true;
                    Current.Properties[skipHelloKey] = Settings.SkipHello;
                    Current.SavePropertiesAsync();
                };
                MainPage.Navigation.PushAsync(new HelloPage(tapped));
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
