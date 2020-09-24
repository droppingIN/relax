using com.on.relax.your.eyes.logic;
using Xamarin.Forms;

namespace com.on.relax.your.eyes.xam
{
    public partial class App : Application
    {
        private PropertyHandler properties;
        public App()
        {
            InitializeComponent();

            properties = new PropertyHandler(Current.Properties);

            if (null == StateMachineProvider.Get())
            {
                InitStateMachine(Current, properties);
            }

            MainPage = new NavigationPage(new WorkPage());

            var skipHello = properties.Get(Settings.Instance.SkipHello, false);
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
            properties.Set(Settings.Instance.SkipHello, true);
            Current.SavePropertiesAsync();
        }

        private void InitStateMachine(Application current, PropertyHandler props)
        {
            var stateAtStartup = (State)properties.Get(Settings.Instance.StateKey, (int)State.Unknown);
            if (State.Unknown == stateAtStartup)
            {
                stateAtStartup = State.Off;
                props.Set(Settings.Instance.StateKey, (int)stateAtStartup);
                current.SavePropertiesAsync();
            }
            StateMachineProvider.Initilaize(stateAtStartup);
        }
    }
}
