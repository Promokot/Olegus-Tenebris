using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public HealthManager healthManager {  get; private set; }
    public DamageManager damageManager { get; private set; }

    private void Awake()
    {
        healthManager = new HealthManager();
        damageManager = new DamageManager();
    }
}
