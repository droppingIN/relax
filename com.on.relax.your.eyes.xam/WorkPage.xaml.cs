using com.on.relax.your.eyes.logic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Action = com.on.relax.your.eyes.logic.Action;

namespace com.on.relax.your.eyes.xam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkPage : ContentPage
    {
        private IStateMachine sm;
        public State State => sm.State;

        public WorkPage()
        {
            InitializeComponent();

            sm = StateMachineProvider.Get();

            OnClick = new Command<Action>((Action action) =>
            {
                var previous = sm.State;
                var newState = sm.SwitchState(action);
                if(newState != previous)
                    OnPropertyChanged(nameof(State));
            });
            BindingContext = this;
        }

        public ICommand OnClick { private set; get; }
    }
}