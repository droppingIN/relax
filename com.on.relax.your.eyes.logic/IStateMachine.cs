namespace com.on.relax.your.eyes.logic
{
    public interface IStateMachine
    {
        State SwitchState(UserDialog userDialog);
        State State { get; }
    }
}
