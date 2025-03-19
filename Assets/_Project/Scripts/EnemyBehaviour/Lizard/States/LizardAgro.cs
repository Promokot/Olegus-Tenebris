using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using static Unity.VisualScripting.Member;

public class LizardAgro : LizardBaseState
{
    public override void EnterState(BaseBehaviourManager manager)
    {
        base.EnterState(manager);
        stateManager.SetTarget(stateManager.player);
        stateManager.SetMoveSpeed(stateManager.WalkSpeed);
    }
    public override void UpdateState(BaseBehaviourManager manager)
    {
        base.UpdateState(manager);

        NavMeshPath path = new NavMeshPath();
        NavMesh.CalculatePath(stateManager.transform.position, stateManager.player.transform.position, NavMesh.AllAreas, path);
        float distance = 0;
        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            distance += (path.corners[i] - path.corners[i + 1]).magnitude;
        }
        if(distance != 0)
        {
            if (distance > stateManager.AgroRadius)
            {
                stateManager.SwitchState(stateManager.lizardIdle);
                return;
            }
            else if(distance < stateManager.AttackRadius)
            {
                stateManager.SwitchState(stateManager.lizardAttack);
                return;
            }
        }

        


    }
}
