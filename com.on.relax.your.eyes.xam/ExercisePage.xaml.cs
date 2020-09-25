using com.on.relax.your.eyes.logic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace com.on.relax.your.eyes.xam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    // ReSharper disable once RedundantExtendsListEntry
    public partial class ExercisePage : ContentPage
    {
        public ExerciseViewModel CurrentExercise { get; }
        public ExercisePage(ExerciseViewModel viewModel)
        {
            CurrentExercise = viewModel;
            InitializeComponent();
        }
    }
}