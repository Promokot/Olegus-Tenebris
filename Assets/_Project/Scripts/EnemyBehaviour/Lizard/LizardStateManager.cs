using UnityEngine;
using UnityEngine.AI;

public class LizardStateManager : BaseBehaviourManager
{

    public LizardAgro lizardAgro { get; private set; } = new LizardAgro();
    public LizardAttack lizardAttack { get; private set; } = new LizardAttack();
    public LizardIdle lizardIdle { get; private set; } = new LizardIdle();


    private void Start()
    {
        SwitchState(lizardAgro);
    }
}
