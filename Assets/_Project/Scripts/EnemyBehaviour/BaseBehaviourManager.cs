using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BaseBehaviourManager : MonoBehaviour, IBehaviourManager
{
    protected BaseState currentState;
    public Transform target { get; private set; }

    [SerializeField] public float moveSpeed { get; protected set; }
    [SerializeField] public float rotationSpeed { get; protected set; }
    bool isRotating = false;
    public void SwitchState(BaseState newState)
    {
        Debug.Log("test");
        if (currentState != null) currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
        Debug.Log(this);
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

    protected virtual void Update()
    {
        if (isRotating) RotateToTarget();
    }
}
