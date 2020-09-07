namespace com.on.relax.your.eyes.logic
{
    public interface IStateMachine
    {
        State SwitchState(Action action);
        State State { get; }
    }
}
