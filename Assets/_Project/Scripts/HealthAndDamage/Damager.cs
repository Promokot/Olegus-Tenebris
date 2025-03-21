using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] Damage _damage;


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IDamageDetectable>(out IDamageDetectable detector))
        {
            detector.DetectDamage(_damage);
        }
    }
}
