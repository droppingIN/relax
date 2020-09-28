using Android.App;
using Android.Content;
using com.on.relax.your.eyes.logic;
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
            if (null == context)
                Debug.WriteLine("WARNING: context is null");
            else
            {
                var extra = intent.GetStringExtra(nameof(UserDialog));
                if (null != extra && UserDialog.ExercisePostpone.ToString() == extra)
                {
                    var flags = PendingIntentFlags.UpdateCurrent;
                    var id = (int)UserDialog.ExercisePostpone;
                    var pending = PendingIntent.GetBroadcast(context, id, intent, flags);
                    if (null != pending)
                        pending.Cancel();
                    Notifications.Cancel(context);
                }
                else
                {
                    var startIntent = IntentFactory.GetPending(context, UserDialog.Start);
                    var postponeIntent = IntentFactory.GetPending(context, UserDialog.ExercisePostpone);

                    var title = "hey! time to eyes gym!";
                    var text = "press start to do the eyes gym or postpone to reschedule the alarm";
                    var builder = Notifications.GetBuilder(context, startIntent, title, text);

                    builder.AddAction(Resource.Drawable.ic_media_pause, "postpone", postponeIntent);
                    builder.AddAction(Resource.Drawable.ic_menu_view, "start", startIntent);

                    Notifications.Show(context, builder);
                }
            }
        }
        //if(null != startMainActivityIntent.ResolveActivity(context.PackageManager))
        //{
        //context.StartActivity(startMainActivityIntent);
        //}
    }
}