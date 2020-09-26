using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Content;

namespace com.on.relax.your.eyes.droid
{
    [Activity(
            Label = "RelaxYourEyes",
            Icon = "@mipmap/icon",
            Theme = "@style/MainTheme",
            MainLauncher = true,
            ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize
    )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Notifications.CreateChannel(this);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            if(!Xamarin.Forms.Forms.IsInitialized)
                Xamarin.Forms.Forms.Init(this, savedInstanceState);

            var alarmHandler = new AlarmImpl(this);
            LoadApplication(new xam.App(alarmHandler));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public static Intent GetStartIntent(Context context)
        {
            var startMainActivityIntent = new Intent(context, typeof(MainActivity));
            startMainActivityIntent.SetAction(Intent.ActionMain);
            //var flags = ActivityFlags.NewTask | ActivityFlags.ClearTop | ActivityFlags.ReorderToFront;
            var flags = ActivityFlags.NewTask | ActivityFlags.ReorderToFront;
            startMainActivityIntent.SetFlags(flags);
            return startMainActivityIntent;
        }
    }
}