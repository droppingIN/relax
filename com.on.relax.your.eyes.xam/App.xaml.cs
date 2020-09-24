using com.on.relax.your.eyes.logic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace com.on.relax.your.eyes.xam
{
    public partial class App : Application
    {
        ISingleAlarm alarmHandler;
        public App(ISingleAlarm alarmImpl)
        {
            InitializeComponent();

            alarmHandler = alarmImpl;
            ApplicationState.Init();

            var tryChangeState = new Command<Action>((Action action) =>
            {
                ApplicationState.TryChangeState(action, alarmImpl);
            });
            MainPage = new NavigationPage(new WorkPage(tryChangeState));

            var skipHello = Current.Properties.Get(Settings.Instance.SkipHello, false);
            if (!skipHello)
                MainPage.Navigation.PushAsync(new HelloPage(CloseHelloPage));
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

        private void CloseHelloPage()
        {
            MainPage.Navigation.PopAsync();
            Current.Properties.Set(Settings.Instance.SkipHello, true);
            Current.SavePropertiesAsync();
        }
    }
}
