using System.Collections.Generic;

namespace com.on.relax.your.eyes.logic
{
    //(State, Action) is a lightweight tuple
    public interface IStateMachine
    {
        State SwitchState(Action action);
        State State { get; }
    }
}
