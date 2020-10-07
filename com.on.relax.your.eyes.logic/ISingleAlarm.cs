namespace com.on.relax.your.eyes.logic
{
    public interface ISingleAlarm
    {
        void ScheduleSingleAlarm(long nextAlarmInMs);
        void CancelSingleAlarm();
    }
}
