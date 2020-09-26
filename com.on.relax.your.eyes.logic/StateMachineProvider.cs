using System;
using System.Runtime.CompilerServices;
namespace com.on.relax.your.eyes.logic
{
    public static class StateMachineProvider
    {
        //singleton impl
        // ReSharper disable once EmptyConstructor
        static StateMachineProvider() { }
        private static IStateMachine _theOnlyState;
        public static IStateMachine Get()
        {
            return _theOnlyState;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void Initialize(State initialState)
        {
            if(null != _theOnlyState)
                throw new InvalidOperationException("State is already initialized!");
            var defaultTransitions = StateMachine.InitialTransitions;
            _theOnlyState = new StateMachine(defaultTransitions, initialState);
        }
    }
}
