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
                Settings.Instance.SkipHello = (bool)Current.Properties[skipHelloKey];

            MainPage = new NavigationPage(new WorkPage());

            if (!Settings.Instance.SkipHello)
            {
                Action tapped = () =>
                {
                    MainPage.Navigation.PopAsync();
                    Settings.Instance.SkipHello = true;
                    Current.Properties[skipHelloKey] = Settings.Instance.SkipHello;
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
