using Xamarin.Forms;

namespace com.on.relax.your.eyes.uwp
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new com.on.relax.your.eyes.xam.App());
        }
    }
}
