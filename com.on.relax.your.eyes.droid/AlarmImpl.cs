using Android.App;
using Android.OS;
using Android.Content;
using com.on.relax.your.eyes.logic;

namespace com.on.relax.your.eyes.droid
{
    public class AlarmImpl : ISingleAlarm
    {
        private readonly ContextWrapper _context;
        private PendingIntent _alarmIntent;
        private AlarmManager _alarmManager;

        public AlarmImpl(ContextWrapper context)
        {
            _context = context;
        }

        private AlarmManager GetLazyAlarmManager()
        {
            if (null == _alarmManager)
                _alarmManager = (AlarmManager)_context.GetSystemService(Context.AlarmService);
            return _alarmManager;
        }

        private PendingIntent GetLazyAlarmIntent()
        {
            if (null == _alarmIntent)
            {
                var intent = new Intent(_context, typeof(EyesGymReceiver));
                _alarmIntent = PendingIntent.GetBroadcast(_context, 0, intent, 0);
            }
            return _alarmIntent;
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