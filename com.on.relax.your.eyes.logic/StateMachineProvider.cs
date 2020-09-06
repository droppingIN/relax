namespace com.on.relax.your.eyes.logic
{
    //(State, Action) is a lightweight tuple
    public static class StateMachineProvider
    {
        private static IStateMachine theOnlyState = null;
        public static IStateMachine Get()
        {
            if(null == theOnlyState)
            {
                theOnlyState = new StateMachine(StateMachine.InitialTransitions);
            }
            return theOnlyState;
        }
    }
}
