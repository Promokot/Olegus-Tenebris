using UnityEngine;

public class LizardAttack : LizardBaseState
{
    public LizardAttack(ExitStateAnimationConfirmation animationConfirmation) : base(animationConfirmation)
    {
    }

    public override void EnterState(BaseBehaviourManager manager)
    {
        base.EnterState(manager);
        stateManager.animator.SetBool("CloseCombat", true);
        stateManager.SetMoveSpeed(0);
    }
    public override void UpdateState(BaseBehaviourManager manager)
    {
        base.UpdateState(manager);

        float distance = stateManager.CalculateDistanceToPlayer();
        if((distance > stateManager.AttackRadius) && (distance != float.PositiveInfinity))
        {
            isSwitchable = true;
            return;
        }
        else
        {
            isSwitchable = false;
            return;
        }
    }
    public override void ExitState(BaseBehaviourManager manager)
    {
        base.ExitState(manager);
        
    }
    protected override void AnimationEventCheck()
    {
        base.AnimationEventCheck();
        if(isSwitchable)
        {
            stateManager.animator.SetBool("CloseCombat", false);
            stateManager.SwitchState(stateManager.lizardAgro);
        }
    }
}
