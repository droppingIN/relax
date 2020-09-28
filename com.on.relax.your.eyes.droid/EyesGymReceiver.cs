using System;
using Android.App;
using Android.Content;
using com.on.relax.your.eyes.logic;
using com.@on.relax.your.eyes.xam.Localization;
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
        private const UserDialog PostponeDialog = UserDialog.ExercisePostpone;
        private const UserDialog AcceptDialog = UserDialog.ExerciseAccept;
        public override void OnReceive(Context context, Intent intent)
        {
            if (null == context)
                Debug.WriteLine("WARNING: context is null");
            else
            {
                var extra = intent.GetStringExtra(nameof(UserDialog));
                if (null != extra)
                {
                    var extraAsEnum = Enum.Parse(typeof(UserDialog), extra);
                    switch(extraAsEnum)
                    {
                        case PostponeDialog:
                            var flags = PendingIntentFlags.UpdateCurrent;
                            var id = (int)UserDialog.ExercisePostpone;
                            var pending = PendingIntent.GetBroadcast(context, id, intent, flags);
                            if (null != pending)
                                pending.Cancel();
                            break;
                        case AcceptDialog:
                            var mainActivityIntent = IntentFactory.GetStartIntent(context);
                            context.StartActivity(mainActivityIntent);
                            break;
                    }
                    Notifications.Cancel(context);
                }
                else
                {
                    var startIntent = IntentFactory.GetPending(context, AcceptDialog, typeof(EyesGymReceiver));
                    var postponeIntent = IntentFactory.GetPending(context, PostponeDialog, typeof(EyesGymReceiver));

                    var title = Strings.ExerciseSuggest;
                    var text = "You are working: " ; // todo hours of work in text here
                    var builder = Notifications.GetBuilder(context, startIntent, title, text);

                    builder.AddAction(Resource.Drawable.ic_media_pause, Strings.ExercisePostpone, postponeIntent);
                    builder.AddAction(Resource.Drawable.ic_menu_view, Strings.ExerciseAccept, startIntent);

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