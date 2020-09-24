using System;
using System.Runtime.CompilerServices;
namespace com.on.relax.your.eyes.logic
{
    public sealed class StateMachineProvider
    {
        //singleton impl
        static StateMachineProvider() { }
        private StateMachineProvider() { }
        private static IStateMachine theOnlyState = null;
        public static IStateMachine Get()
        {
            return theOnlyState;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void Initilaize(State initialState)
        {
            if(null != theOnlyState)
                throw new InvalidOperationException("State is already initialized!");
            var default_transitions = StateMachine.InitialTransitions;
            theOnlyState = new StateMachine(default_transitions, initialState);
        }
    }
}
