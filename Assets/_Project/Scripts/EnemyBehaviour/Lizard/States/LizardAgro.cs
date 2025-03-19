using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using static Unity.VisualScripting.Member;

public class LizardAgro : LizardBaseState
{
    public override void EnterState(BaseBehaviourManager manager)
    {
        base.EnterState(manager);
        stateManager.SetTarget(stateManager.player);
        stateManager.SetMoveSpeed(stateManager.WalkSpeed);
    }
    public override void UpdateState(BaseBehaviourManager manager)
    {
        base.UpdateState(manager);

        float distance = stateManager.CalculateDistanceToPlayer();
        if(distance != 0)
        {
            if (distance > stateManager.AgroRadius)
            {
                stateManager.SwitchState(stateManager.lizardIdle);
                return;
            }
            else if(distance < stateManager.AttackRadius)
            {
                stateManager.SwitchState(stateManager.lizardAttack);
                return;
            }
        }
    }
}
