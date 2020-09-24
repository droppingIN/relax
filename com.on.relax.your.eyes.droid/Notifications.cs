using Android.App;
using Android.Content;
using Android.OS;

namespace com.on.relax.your.eyes.droid
{
    public static class Notifications
    {
        public static readonly string GLOBAL_CHANNEL_ID = "B4F6E029-C9C4-4367-9A64-BC9529E44A0D";
        public static void CreateChannel(Context context)
        {

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channelName = context.GetString(Resource.String.notification_channel_name);
                var channelDescription = context.GetString(Resource.String.notification_channel_description);
                var channel = new NotificationChannel(GLOBAL_CHANNEL_ID, channelName, NotificationImportance.Default)
                {
                    Description = channelDescription
                };

                var notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
                notificationManager.CreateNotificationChannel(channel);
            }
        }
    }
}