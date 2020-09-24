using com.on.relax.your.eyes.logic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UserAction = com.on.relax.your.eyes.logic.Action;
using Action = System.Action;

namespace com.on.relax.your.eyes.xam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkPage : ContentPage
    {
        private IStateMachine sm;
        private Action OnStateChanged;
        public State State => sm.State;

        public WorkPage(Action stateChanged)
        {
            InitializeComponent();

            sm = StateMachineProvider.Get();
            OnStateChanged = stateChanged;

            OnClick = new Command<UserAction>((UserAction action) =>
            {
                var previous = sm.State;
                var newState = sm.SwitchState(action);
                if(newState != previous)
                    OnPropertyChanged(nameof(State));
                OnStateChanged();
            });
            BindingContext = this;
        }

        public ICommand OnClick { private set; get; }
    }
}