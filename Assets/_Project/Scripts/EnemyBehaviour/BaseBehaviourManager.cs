using UnityEngine;
using UnityEngine.AI;

public abstract class BaseBehaviourManager : MonoBehaviour
{
    protected BaseState currentState;
    public Transform target { get; private set; }

    private float moveSpeed;
    private float rotationSpeed;





    bool isRotating = false;
    public Transform player { get; private set; }
    public NavMeshAgent navMesh { get; protected set; }
    public void SwitchState(BaseState newState)
    {
        if (currentState != null) currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
    public void RotateToTarget()
    {
        Vector3 direction = (target.transform.position - transform.position);
        direction.y = 0f;
        Quaternion newRotation = Quaternion.LookRotation(direction).normalized;
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
    }
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
    public void SwitchRotation(bool isRotationOn)
    {
        isRotating = isRotationOn;
    }
    public void SetMoveSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }
    public void SetRotationSpeed(float newSpeed)
    {
        rotationSpeed = newSpeed;
    }
    protected virtual void FixedUpdate()
    {
        if (isRotating) RotateToTarget();
        if (target != null) navMesh.destination = target.position;
    }
    protected virtual void Start()
    {
        if (TryGetComponent<NavMeshAgent>(out NavMeshAgent agent)) navMesh = agent;
        if (GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            Debug.LogError("1 GameObject With Tag 'Player' is Required in scene");
        }
    }
    protected virtual void Update()
    {
        try
        {
            currentState.UpdateState(this);
        }
        catch
        {
            Debug.LogWarning("Current state is Null on " + gameObject);
        }
    }
}
