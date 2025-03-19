using UnityEngine;

public class LizardIdle : LizardBaseState
{
    public override void EnterState(BaseBehaviourManager manager)
    {
        base.EnterState(manager);

        stateManager.SetMoveSpeed(0);
    }

    public override void UpdateState(BaseBehaviourManager manager)
    {
        base.UpdateState(manager);

        if(stateManager.CalculateDistanceToPlayer() < stateManager.AgroRadius)
        {
            stateManager.SwitchState(stateManager.lizardAgro);
            return;
        }
    }
}
