using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;

namespace com.on.relax.your.eyes.droid
{
    public static class Notifications
    {
        private const string GlobalChannelId = "B4F6E029-C9C4-4367-9A64-BC9529E44A0D";
        public static void CreateChannel(Context context)
        {

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channelName = context.GetString(Resource.String.notification_channel_name);
                var channelDescription = context.GetString(Resource.String.notification_channel_description);
                var channel = new NotificationChannel(GlobalChannelId, channelName, NotificationImportance.Default)
                {
                    Description = channelDescription
                };

                var notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
                if (null != notificationManager)
                {
                    notificationManager.CreateNotificationChannel(channel);
                }
            }
        }

        public static NotificationCompat.Builder GetBuilder(Context context, PendingIntent pendingIntent, string title, string text)
        {
            var builder = new NotificationCompat.Builder(context, GlobalChannelId)
                .SetContentTitle(title)
                .SetContentText(text)
                .SetDefaults((int)(NotificationDefaults.Sound | NotificationDefaults.Vibrate))
                .SetSmallIcon(Resource.Drawable.ic_menu_info_details)
                .SetContentIntent(pendingIntent)
                .SetAutoCancel(true);
            return builder;
        }

        public static NotificationCompat.Builder AddAction(this NotificationCompat.Builder builder, int iconResourceId,  string title, PendingIntent intent)
        {
            builder.AddAction(iconResourceId, title, intent);
            return builder;
        }
        
        private const int NotificationId = 0;

        public static void Show(Context context, NotificationCompat.Builder builder)
        {
            Notification notification = builder.Build();
            var notificationManager = (NotificationManager) context.GetSystemService(Context.NotificationService);

            if (null != notificationManager)
                notificationManager.Notify(NotificationId, notification);
        }

        public static void Cancel(Context context)
        {
            var notificationManager = (NotificationManager) context.GetSystemService(Context.NotificationService);

            if (null != notificationManager)
                notificationManager.Cancel(NotificationId);
        }
    }
}