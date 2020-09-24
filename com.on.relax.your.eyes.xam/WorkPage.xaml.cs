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
        public State State => sm.State;
        private Command<UserAction> TryChangeState;

        public WorkPage(Command<UserAction> requestStateChange)
        {
            InitializeComponent();

            sm = StateMachineProvider.Get();

            TryChangeState = requestStateChange;
            OnClick = new Command<UserAction>((UserAction action) => {
                var currentState = sm.State;
                TryChangeState.Execute(action);
                var newState = sm.State;
                if(currentState != newState)
                {
                    OnPropertyChanged(nameof(State));
                }
            });
            BindingContext = this;
        }

        public ICommand OnClick { private set; get; }
    }
}