using Android.App;
using Android.Content;
using com.on.relax.your.eyes.logic;

namespace com.on.relax.your.eyes.droid
{
    public static class IntentFactory
    {
        private const PendingIntentFlags OneShot = PendingIntentFlags.OneShot;

        public static PendingIntent GetPending(Context context, UserDialog id)
        {
            if (UserDialog.ExercisePostpone == id)
                return GetPostponePending(context, id);

            return GetStartActivityPending(context, id);
        }

        private static Intent GetStartIntent(Context context)
        {
            var startMainActivityIntent = new Intent(context, typeof(MainActivity));
            startMainActivityIntent.SetAction(Intent.ActionMain);
            //var flags = ActivityFlags.NewTask | ActivityFlags.ClearTop | ActivityFlags.ReorderToFront;
            var flags = ActivityFlags.NewTask | ActivityFlags.ReorderToFront;
            startMainActivityIntent.SetFlags(flags);
            return startMainActivityIntent;
        }

        private static PendingIntent GetStartActivityPending(Context context, UserDialog id)
        {
            var intent = GetStartIntent(context);
            var pendingIntent = PendingIntent.GetActivity(context, (int)id, intent, OneShot);
            return pendingIntent;
        }

        private static PendingIntent GetPostponePending(Context context, UserDialog id)
        {
            var intent = new Intent(context, typeof(EyesGymReceiver));
            intent.PutExtra(nameof(UserDialog), id.ToString());
            var pendingIntent =  PendingIntent.GetBroadcast(context, (int)id, intent, OneShot);
            return pendingIntent;
        }
    }
}