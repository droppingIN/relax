using com.on.relax.your.eyes.logic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace com.on.relax.your.eyes.xam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExercisePage : ContentPage
    {
        public ExerciseViewModel CurrentExcercise { get; private set; }
        public ExercisePage(ExerciseViewModel viewModel)
        {
            CurrentExcercise = viewModel;
            InitializeComponent();
        }
    }
}