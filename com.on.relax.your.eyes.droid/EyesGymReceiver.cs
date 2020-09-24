using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Debug = System.Diagnostics.Debug;

namespace com.on.relax.your.eyes.droid
{
    [BroadcastReceiver(
            DirectBootAware = false,
            Enabled = true,
            Exported = false
        )
    ]
    public class EyesGymReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            //todo show notification?
            if (null == context)
                Debug.WriteLine("WARNING: context is null");
            else
            {
                ShowNotification(context);
            }
        }

        void ShowNotification(Context context)
        {
            const int pendingIntentId = 0;
            const PendingIntentFlags flags = PendingIntentFlags.OneShot;
            var intent = MainActivity.GetStartIntent(context);
            var pendingIntent = PendingIntent.GetActivity(context, pendingIntentId, intent, flags);

            var builder = new NotificationCompat.Builder(context, Notifications.GLOBAL_CHANNEL_ID)
                .SetContentTitle("Time to relax your eyes!")//todo resource
                .SetContentText("Hello World! This is my first notification!")//todo resource
                .SetDefaults((int)(NotificationDefaults.Sound | NotificationDefaults.Vibrate))
                .SetSmallIcon(Resource.Drawable.ic_menu_info_details)
                .SetContentIntent(pendingIntent);

            Notification notification = builder.Build();
            var notificationManager = context.GetSystemService(Context.NotificationService) as NotificationManager;

            const int notificationId = 0;
            notificationManager.Notify(notificationId, notification);
        }

        //if(null != startMainActivityIntent.ResolveActivity(context.PackageManager))
        //{
        //context.StartActivity(startMainActivityIntent);
        //}
    }
}