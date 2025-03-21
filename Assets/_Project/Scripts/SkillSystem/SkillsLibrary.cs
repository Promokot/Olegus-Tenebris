using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SkillsLibrary", menuName = "RPG/Skills/SkillsLibrary", order = 1)]
public class SkillsLibrary : ScriptableObject
{
    [System.Serializable]
    public struct SkillInfo
    {
        [SerializeField] private string _skillName;
        [SerializeField] private string _skillDescription;
        [SerializeField] private float _skillBasicCooldown;
        [SerializeField] private Sprite _skillIcon;
        [SerializeField] private GameObject _skillPrefab;

        public string SkillName => _skillName;
        public string SkillDescription => _skillDescription;
        public float SkillBasicCooldown => _skillBasicCooldown;
        public Sprite SkillIcon => _skillIcon;
        public GameObject SkillPrefab => _skillPrefab;
    }

    [SerializeField]
    private List<SkillInfo> _skills = new List<SkillInfo>();
    public List<SkillInfo> Skills => _skills;

    public SkillInfo GetSkill(int index)
    {
        if (index >= 0 && index < _skills.Count)
        {
            return _skills[index];
        }
        else
        {
            Debug.LogError("Skill index out of range!");
            return new SkillInfo();
        }
    }
}