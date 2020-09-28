using System.Collections.Generic;

namespace com.on.relax.your.eyes.logic
{
    //(State, UserDialog) is a lightweight tuple
    using TransitionMatrix = Dictionary<(State, UserDialog), State>;

    internal sealed class StateMachine : IStateMachine
    {
        public State State { get; private set; }

        private readonly TransitionMatrix _transitionMatrix;

        internal StateMachine(in TransitionMatrix transitions, State initialState)
        {
            State = initialState;
            _transitionMatrix = transitions;
        }

        public State SwitchState(UserDialog userDialog)
        {
            var key = (State, action: userDialog);
            if (_transitionMatrix.ContainsKey(key))
                State = _transitionMatrix[key];
            return State;
        }

        public static TransitionMatrix InitialTransitions
        {
            get
            {
                // ReSharper disable once UseObjectOrCollectionInitializer
                var matrix = new TransitionMatrix();
                // Lifecycle
                matrix[(State.Off, UserDialog.Start)] = State.On;
                matrix[(State.On, UserDialog.Stop)] = State.Off;
                matrix[(State.Pause, UserDialog.Stop)] = State.Off;
                // Pause
                matrix[(State.On, UserDialog.PauseBegin)] = State.Pause;
                matrix[(State.Pause, UserDialog.PauseEnd)] = State.On;
                // Exercise
                matrix[(State.On, UserDialog.ExerciseSuggest)] = State.ExerciseSuggested;
                matrix[(State.ExerciseSuggested, UserDialog.ExerciseAccept)] = State.Exercise;
                matrix[(State.ExerciseSuggested, UserDialog.ExercisePostpone)] = State.On;
                matrix[(State.Exercise, UserDialog.ExerciseEnd)] = State.On;
                return matrix;
            }
        }
    }
}
