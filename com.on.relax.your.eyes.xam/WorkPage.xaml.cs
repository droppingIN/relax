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
        private State state;
        public State State
        {
            get => state;
            set
            {
                if(value != state)
                {
                    state = value;
                    OnPropertyChanged(nameof(State));
                }
            }
        }

        public WorkPage()
        {
            InitializeComponent();
            State = StateMachineProvider.Get().State;

            OnClick = new Command<Action>((Action action) =>
            {
                State = StateMachineProvider.Get().SwitchState(action);
            });
            BindingContext = this;
        }

        public ICommand OnClick { private set; get; }
    }
}