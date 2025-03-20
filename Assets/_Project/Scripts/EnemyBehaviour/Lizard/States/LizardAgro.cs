using Unity.VisualScripting;
using UnityEngine;

public class LizardAgro : LizardBaseState
{
    public LizardAgro() : base()
    {
    }

    public override void EnterState(BaseBehaviourManager manager)
    {
        base.EnterState(manager);
        stateManager.animator.SetBool("isInAgroRadius",true);
        stateManager.SetTarget(stateManager.player);
        stateManager.SetMoveSpeed(stateManager.WalkSpeed);

        Debug.Log("Agro Enter");
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
