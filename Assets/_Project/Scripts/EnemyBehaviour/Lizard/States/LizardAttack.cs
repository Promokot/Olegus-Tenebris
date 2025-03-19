using UnityEngine;

public class LizardAttack : LizardBaseState
{
    public override void EnterState(BaseBehaviourManager manager)
    {
        base.EnterState(manager);

        stateManager.SetMoveSpeed(0);
    }
    public override void UpdateState(BaseBehaviourManager manager)
    {
        base.UpdateState(manager);

        float distance = stateManager.CalculateDistanceToPlayer();
        if((distance > stateManager.AttackRadius) && (distance != float.PositiveInfinity))
        {
            stateManager.SwitchState(stateManager.lizardAgro);
        }
    }
}
