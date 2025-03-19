public abstract class BaseState
{   public abstract void EnterState(BaseBehaviourManager manager);
    public abstract void UpdateState(BaseBehaviourManager manager);
    public abstract void ExitState(BaseBehaviourManager manager);

}
