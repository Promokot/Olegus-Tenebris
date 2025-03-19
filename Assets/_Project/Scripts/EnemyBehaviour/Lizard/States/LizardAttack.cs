using UnityEngine;

public class LizardAttack : LizardBaseState
{
    public override void EnterState(BaseBehaviourManager manager)
    {
        base.EnterState(manager);

        stateManager.SetMoveSpeed(0);
    }
}
