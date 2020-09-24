using Android.App;
using Android.OS;
using Android.Content;
using com.on.relax.your.eyes.logic;

namespace com.on.relax.your.eyes.droid
{
    public class AlarmImpl : ISingleAlarm
    {
        private ContextWrapper context;
        private PendingIntent alarmIntent = null;
        private AlarmManager alarmManager = null;

        public AlarmImpl(ContextWrapper context)
        {
            this.context = context;
        }

        private AlarmManager GetLazyAlarmManager()
        {
            if (null == alarmManager)
                alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);
            return alarmManager;
        }

        private PendingIntent GetLazyAlarmIntent()
        {
            if (null == alarmIntent)
            {
                var intent = new Intent(context, typeof(EyesGymReceiver));
                alarmIntent = PendingIntent.GetBroadcast(context, 0, intent, 0);
            }
            return alarmIntent;
        }

        public void ScheduleSingleAlarm(long intervalMs)
        {
            var alarmType = AlarmType.ElapsedRealtimeWakeup;
            var nextAlarmAt = SystemClock.ElapsedRealtime() + intervalMs;
            GetLazyAlarmManager().SetRepeating(alarmType, nextAlarmAt, intervalMs, GetLazyAlarmIntent());
            //GetLazyAlarmManager().SetInexactRepeating(alarmType, nextAlarmAt, intervalMs, GetLazyAlarmIntent());
        }

        public void CancelSingleAlarm()
        {
            GetLazyAlarmIntent().Cancel();
        }
    }
}