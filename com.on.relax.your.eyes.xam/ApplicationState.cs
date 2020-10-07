using com.on.relax.your.eyes.logic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace com.on.relax.your.eyes.xam
{
    public class ApplicationState
    {
        public static void Init()
        {
            if (null == StateMachineProvider.Get())
            {
                var app = Application.Current;
                var stateAtStartup = (State)app.Properties.Get(Settings.Instance.StateKey, (int)State.Unknown);
                if (State.Unknown == stateAtStartup)
                {
                    stateAtStartup = State.Off;
                    app.Properties.Set(Settings.Instance.StateKey, (int)stateAtStartup);
                    app.SavePropertiesAsync();
                }
                StateMachineProvider.Initialize(stateAtStartup);
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void TryChangeState(UserDialog requested, ISingleAlarm alarmHandler)
        {
            var sm = StateMachineProvider.Get();
            var previous = sm.State;
            var newState = sm.SwitchState(requested);
            if (newState != previous)
            {
                var nextAlarmInMs = 15000;
                switch (newState)
                {
                    case State.On:
                        //pause to on will reschedule alarm
                        alarmHandler.ScheduleSingleAlarm(nextAlarmInMs);
                        break;
                    case State.Off:
                        alarmHandler.CancelSingleAlarm();
                        break;
                    case State.Pause:
                        //hold alarm: start counting current pause time, then reschedule the alarm to later time
                        alarmHandler.CancelSingleAlarm();
                        break;
                    case State.ExerciseSuggested:
                        //show dialog to accept or postpone the exercise, hold alarm
                        break;
                    case State.Exercise:
                        //show exercise, hold alarm, 
                        break;
                }

                var app = Application.Current;
                app.Properties.Set(Settings.Instance.StateKey, (int)StateMachineProvider.Get().State);
                app.SavePropertiesAsync();
            }
        }
    }
}
