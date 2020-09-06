using System;
using Xamarin.Forms;

namespace com.on.relax.your.eyes.xam
{
    public partial class HelloPage : ContentPage
    {
        public HelloPage(Action onAnyTapped)
        {
            tapped += onAnyTapped;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
        }

        private Action tapped;

        private void SignalizeAndResetHandler()
        {
            if (null != tapped)
            {
                tapped();
                foreach (var invocation in tapped.GetInvocationList())
                    tapped -= (Action)invocation;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            SignalizeAndResetHandler();
        }

        protected override bool OnBackButtonPressed()
        {
            SignalizeAndResetHandler();
            return base.OnBackButtonPressed();
        }
    }
}
