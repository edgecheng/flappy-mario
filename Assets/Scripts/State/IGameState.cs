public class IGameState
{
    public string StateName { get; set; } = "IGameState";

    public IGameState() {}

    public virtual void StateBegin() {}
    public virtual void StateEnd() {}
    public virtual void StateUpdate() {}
}
