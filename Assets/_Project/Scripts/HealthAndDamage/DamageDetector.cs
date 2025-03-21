using UnityEngine;



public class DamageDetector : MonoBehaviour, IDamageDetectable
{
    [SerializeField] DetectorType _thisDetectorType;
    [SerializeField] HealthManager healthManager;
    public void DetectDamage(Damage damage)
    {
        if ((_thisDetectorType == DetectorType.enemy) && (damage.Direction == DamageDirection.Player)) return;
        if ((_thisDetectorType == DetectorType.player) && (damage.Direction == DamageDirection.Enemy)) return;

        switch (damage.DamageType)
        {
            case DamageType.Physical:
            {
                    //
                    try
                    {
                        healthManager.ChangeHealth(-damage.Amount);
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
                        healthManager.ChangeHealth(-damage.Amount);
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
