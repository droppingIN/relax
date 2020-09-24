using com.on.relax.your.eyes.logic;
using Xamarin.Forms;

namespace com.on.relax.your.eyes.uwp
{

    public class SingleAlarmMock : ISingleAlarm
    {
        public void CancelSingleAlarm()
        {
            throw new System.NotImplementedException();
        }

        public void ScheduleSingleAlarm(long intervalMs)
        {
            throw new System.NotImplementedException();
        }
    }

    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new xam.App(new SingleAlarmMock()));
        }

    }
}
