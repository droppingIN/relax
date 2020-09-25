using System;
using Xamarin.Forms;

namespace com.on.relax.your.eyes.xam
{
    // ReSharper disable once RedundantExtendsListEntry
    public partial class HelloPage : ContentPage
    {
        public HelloPage(Action onAnyTapped)
        {
            _tapped += onAnyTapped;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
        }

        ~HelloPage()
        {
            _tapped.ResetAll();
        }

        private readonly Action _tapped;

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            _tapped.FireAndReset();
        }

        protected override bool OnBackButtonPressed()
        {
            _tapped.FireAndReset();
            return base.OnBackButtonPressed();
        }
    }
}
