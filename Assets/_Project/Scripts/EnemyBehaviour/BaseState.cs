using System;

public abstract class BaseState
{   public virtual void EnterState(BaseBehaviourManager manager)
    {
        isSwitchable = false;
        AnimationStateChangeCheck += AnimationEventCheck;
        if(animationConfirmation == ExitStateAnimationConfirmation.Required) manager.OnExitStateThroughAnimationAttempt += AnimationStateChangeCheck;
    }
    public virtual void UpdateState(BaseBehaviourManager manager)
    {

    }
    public virtual void ExitState(BaseBehaviourManager manager)
    {
        if (animationConfirmation == ExitStateAnimationConfirmation.Required) manager.OnExitStateThroughAnimationAttempt -= AnimationStateChangeCheck;
        AnimationStateChangeCheck = null;
        isSwitchable = false;
    }

    public ExitStateAnimationConfirmation animationConfirmation { get; protected set; }
    public string confirmWord { get; protected set; }
    public BaseState(ExitStateAnimationConfirmation animationConfirmation)
    {
        this.animationConfirmation = animationConfirmation;
    }
    public BaseState()
    {
        animationConfirmation = ExitStateAnimationConfirmation.NotRequired;
    }

    private Action AnimationStateChangeCheck;

    protected virtual void AnimationEventCheck()
    {
        //
    }
    protected bool isSwitchable = false;
}
public enum ExitStateAnimationConfirmation { NotRequired, Required }
