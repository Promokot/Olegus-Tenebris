using UnityEngine;

public class Skill_Test : SkillBase
{
    public override void RunSkill()
    {
        Debug.Log("Skill_Test activated!");
        SelfDestroy(5f);
    }
}