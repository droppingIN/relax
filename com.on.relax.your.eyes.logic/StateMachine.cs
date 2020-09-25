using System.Collections.Generic;

namespace com.on.relax.your.eyes.logic
{
    //(State, Action) is a lightweight tuple
    using TransitionMatrix = Dictionary<(State, Action), State>;

    internal sealed class StateMachine : IStateMachine
    {
        public State State { get; private set; }

        private readonly TransitionMatrix _transitionMatrix;

        internal StateMachine(in TransitionMatrix transitions, State initialState)
        {
            State = initialState;
            _transitionMatrix = transitions;
        }

        public State SwitchState(Action action)
        {
            var key = (State, action);
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
                matrix[(State.Off, Action.Start)] = State.On;
                matrix[(State.On, Action.Stop)] = State.Off;
                matrix[(State.Pause, Action.Stop)] = State.Off;
                // Pause
                matrix[(State.On, Action.PauseBegin)] = State.Pause;
                matrix[(State.Pause, Action.PauseEnd)] = State.On;
                // Exercise
                matrix[(State.On, Action.ExerciseSuggest)] = State.ExerciseSuggested;
                matrix[(State.ExerciseSuggested, Action.ExerciseAccept)] = State.Exercise;
                matrix[(State.ExerciseSuggested, Action.ExercisePostpone)] = State.On;
                matrix[(State.Exercise, Action.ExerciseEnd)] = State.On;
                return matrix;
            }
        }
    }
}
