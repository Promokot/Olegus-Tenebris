using UnityEngine;

public class LizardBaseState : BaseState
{
    protected LizardStateManager stateManager;
    public override void EnterState(BaseBehaviourManager manager)
    {
        stateManager = (LizardStateManager)manager;
    }

    public override void ExitState(BaseBehaviourManager manager)
    {
        
    }

    public override void UpdateState(BaseBehaviourManager manager)
    {
        
    }
}
