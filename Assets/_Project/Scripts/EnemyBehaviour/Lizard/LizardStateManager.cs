using UnityEngine;

public class LizardStateManager : BaseBehaviourManager
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _agroRadius;
    [SerializeField] private float _attackRadius;
    public float AgroRadius
    {
        get { return _agroRadius; }
        private set { _agroRadius = value; }
    }
    public float AttackRadius
    {
        get { return _attackRadius; }
        private set { _attackRadius = value; }
    }
    public float WalkSpeed
    {
        get { return _walkSpeed; }
        private set { _walkSpeed = value; }
    }

    public LizardAgro lizardAgro { get; private set; } = new LizardAgro();
    public LizardAttack lizardAttack { get; private set; } = new LizardAttack();
    public LizardIdle lizardIdle { get; private set; } = new LizardIdle();


    protected override void Start()
    {
        base.Start();
        SetTarget(player);
        SwitchState(lizardIdle);
    }
    protected override void Update()
    {
        base.Update();

        Debug.Log(currentState);
    }
}
