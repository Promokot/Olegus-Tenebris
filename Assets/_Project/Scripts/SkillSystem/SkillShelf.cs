using UnityEngine;
using System.Collections;

public class SkillShelf : MonoBehaviour
{
    [SerializeField]
    private SkillsLibrary _skillsLibrary; // Ссылка на SkillsLibrary

    [SerializeField]
    private int _skillIndexToActivate = 0; // Индекс скилла для активации

    private float _currentCooldownTime = 0f; // Текущее время перезарядки
    private bool _isSkillOnCooldown = false; // Флаг, показывающий, находится ли скилл в перезарядке

    void Start()
    {
        ActivateSkill(_skillIndexToActivate); // Активируем скилл при старте
    }

    void Update()
    {
        if (_isSkillOnCooldown)
        {
            _currentCooldownTime -= Time.deltaTime;
            if (_currentCooldownTime <= 0)
            {
                _isSkillOnCooldown = false;
                Debug.Log("Skill is ready to use!");
            }
        }
    }

    //Активировать скилл по индексу
    public void ActivateSkill(int skillIndex)
    {
        if (_skillsLibrary == null)
        {
            Debug.LogError("SkillsLibrary is not assigned!");
            return;
        }

        if (_isSkillOnCooldown)
        {
            Debug.Log("Skill is on cooldown!");
            return;
        }

        SkillsLibrary.SkillInfo skillInfo = _skillsLibrary.GetSkill(skillIndex);

        if (skillInfo.SkillPrefab == null)
        {
            Debug.LogError("Skill prefab is not assigned for skill index: " + skillIndex);
            return;
        }

        // Создаем инстанс скилла
        GameObject skillInstance = Instantiate(skillInfo.SkillPrefab, transform.position, transform.rotation);

        // Получаем компонент SkillBase
        SkillBase skill = skillInstance.GetComponent<SkillBase>();

        if (skill == null)
        {
            Debug.LogError("Skill prefab does not have a SkillBase component!");
            Destroy(skillInstance); // Уничтожаем созданный объект
            return;
        }

        // Активируем скилл
        skill.Activate();

        // Устанавливаем кулдаун
        _currentCooldownTime = skillInfo.SkillBasicCooldown;
        _isSkillOnCooldown = true;
        Debug.Log("Skill activated! Cooldown: " + _currentCooldownTime);
    }
}