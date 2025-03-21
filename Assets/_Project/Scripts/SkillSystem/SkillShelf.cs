using UnityEngine;
using System.Collections;

public class SkillShelf : MonoBehaviour
{
    [SerializeField]
    private SkillsLibrary _skillsLibrary; // ������ �� SkillsLibrary

    [SerializeField]
    private int _skillIndexToActivate = 0; // ������ ������ ��� ���������

    private float _currentCooldownTime = 0f; // ������� ����� �����������
    private bool _isSkillOnCooldown = false; // ����, ������������, ��������� �� ����� � �����������

    void Start()
    {
        ActivateSkill(_skillIndexToActivate); // ���������� ����� ��� ������
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

    //������������ ����� �� �������
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

        // ������� ������� ������
        GameObject skillInstance = Instantiate(skillInfo.SkillPrefab, transform.position, transform.rotation);

        // �������� ��������� SkillBase
        SkillBase skill = skillInstance.GetComponent<SkillBase>();

        if (skill == null)
        {
            Debug.LogError("Skill prefab does not have a SkillBase component!");
            Destroy(skillInstance); // ���������� ��������� ������
            return;
        }

        // ���������� �����
        skill.Activate();

        // ������������� �������
        _currentCooldownTime = skillInfo.SkillBasicCooldown;
        _isSkillOnCooldown = true;
        Debug.Log("Skill activated! Cooldown: " + _currentCooldownTime);
    }
}