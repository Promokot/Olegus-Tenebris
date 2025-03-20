using UnityEngine;

public abstract class LizardBaseState : BaseState
{
    protected LizardStateManager stateManager;

    protected LizardBaseState(ExitStateAnimationConfirmation animationConfirmation) : base(animationConfirmation)
    {
    }
    protected LizardBaseState() : base()
    {

    }

    public override void EnterState(BaseBehaviourManager manager)
    {
        base.EnterState(manager);
        stateManager = (LizardStateManager)manager;
    }

    public override void ExitState(BaseBehaviourManager manager)
    {
        base.ExitState(manager);
    }

    public override void UpdateState(BaseBehaviourManager manager)
    {
        base.UpdateState(manager);
    }
}
