using UnityEngine;



public class DamageDetector : MonoBehaviour, IDamageDetectable
{
    [SerializeField] DetectorType _thisDetectorType;
    [SerializeField] HealthManager healthManager;
    public void DetectDamage(Damage damage)
    {
        if ((_thisDetectorType == DetectorType.enemy) && (damage.dDirection == DamageDirection.Player)) return;
        if ((_thisDetectorType == DetectorType.player) && (damage.dDirection == DamageDirection.Enemy)) return;

        switch (damage.dDamageType)
        {
            case DamageType.Physical:
            {
                    //
                    try
                    {
                        healthManager.ChangeHealth(damage.dAmount);
                    }
                    catch
                    {
                        Debug.LogError("Missing Target Health Manager On " + this);
                    }

                    break;
            }
            case DamageType.Magical:
            {
                    //
                    try
                    {
                        healthManager.ChangeHealth(damage.dAmount);
                    }
                    catch
                    {
                        Debug.LogError("Missing Target Health Manager On " + this);
                    }
                    break;
            }
            default:
            {
                    //
                    break;
            }
        }
    }
    private enum DetectorType
    {
        enemy, player
    }

}
