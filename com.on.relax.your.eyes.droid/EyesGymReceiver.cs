using System;
using Android.App;
using Android.Content;
using com.on.relax.your.eyes.logic;
using com.on.relax.your.eyes.xam.Localization;
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
            {
                Debug.WriteLine("WARNING: context is null");
                return;
            }

            var extra = intent.GetStringExtra(nameof(UserDialog));
            if (null == extra) // alarm event received
            {
                CreateShowNotification(context);
                return;
            }
            
            var extraAsEnum = (UserDialog)Enum.Parse(typeof(UserDialog), extra);
            switch (extraAsEnum)
            {
                case AcceptDialog:
                    //todo change state and then start activity
                    var mainActivityIntent = IntentFactory.GetStartIntent(context);
                    context.StartActivity(mainActivityIntent);
                    break;
                case PostponeDialog:
                    var alarm = new AlarmImpl(new ContextWrapper(context.ApplicationContext));
                    var nextAlarmInMs = 5000;
                    alarm.ScheduleSingleAlarm(nextAlarmInMs);
                    break;
            }

            CancelPending(context, intent, (int)extraAsEnum);
            Notifications.Cancel(context);
        }

        private void CancelPending(Context context, Intent intent, int id)
        {
            var flags = PendingIntentFlags.UpdateCurrent;
            var pending = PendingIntent.GetBroadcast(context, id, intent, flags);
            if (null != pending)
                pending.Cancel();
        }

        private void CreateShowNotification(Context context)
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

        //if(null != startMainActivityIntent.ResolveActivity(context.PackageManager))
        //{
        //context.StartActivity(startMainActivityIntent);
        //}
    }
}