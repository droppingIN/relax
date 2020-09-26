using com.on.relax.your.eyes.logic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UserAction = com.on.relax.your.eyes.logic.Action;

namespace com.on.relax.your.eyes.xam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    // ReSharper disable once RedundantExtendsListEntry
    public partial class WorkPage : ContentPage
    {
        private readonly IStateMachine _sm;
        public State State => _sm.State;

        public WorkPage(Command<UserAction> requestStateChange)
        {
            InitializeComponent();

            _sm = StateMachineProvider.Get();

            OnClick = new Command<UserAction>(action => {
                var currentState = _sm.State;
                requestStateChange.Execute(action);
                var newState = _sm.State;
                if(currentState != newState)
                {
                    OnPropertyChanged(nameof(State));
                }
            });
            BindingContext = this;
        }

        public ICommand OnClick { get; }
    }
}