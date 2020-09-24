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

        ~HelloPage()
        {
            tapped.ResetAll();
        }

        private Action tapped;

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            tapped.FireAndReset();
        }

        protected override bool OnBackButtonPressed()
        {
            tapped.FireAndReset();
            return base.OnBackButtonPressed();
        }
    }
}
