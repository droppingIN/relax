using com.on.relax.your.eyes.logic;
using Xamarin.Forms;

namespace com.on.relax.your.eyes.xam
{
    // ReSharper disable once RedundantExtendsListEntry
    public partial class App : Application
    {
        public ISingleAlarm AlarmHandler { get; }

        public App(ISingleAlarm alarmImpl)
        {
            InitializeComponent();

            AlarmHandler = alarmImpl;
            ApplicationState.Init();

            var tryChangeState = new Command<UserDialog>(action =>
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
