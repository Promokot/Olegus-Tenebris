using UnityEngine;
using System.Collections;

public abstract class SkillBase : MonoBehaviour
{
    [SerializeField] private float _cooldownTime = 1f;
    [SerializeField] private float _basicDamage = 10f;
    public float CooldownTime => _cooldownTime;

    protected virtual void SpawnCollider() { }

    protected virtual void SelfDestroy(float delay = 0f)
    {
        StartCoroutine(DelayedSelfDestroy(delay));
    }

    private IEnumerator DelayedSelfDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    public void Activate()
    {
        RunSkill();
    }

    public abstract void RunSkill();
}