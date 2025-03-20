using System.Collections;
using UnityEngine;

public class LizardDead : LizardBaseState
{
    public LizardDead() : base()
    {
    }

    public override void EnterState(BaseBehaviourManager manager)
    {
        base.EnterState(manager);
        Debug.Log("weird");
        stateManager.animator.SetBool("Death", true);
        stateManager.SetMoveSpeed(0);
        GameObject.Destroy(stateManager.navMesh);
        if(stateManager.TryGetComponent<Rigidbody>(out Rigidbody rb)) GameObject.Destroy(rb);
        stateManager.StartCoroutine(DrownOnDeath(3,10,1));
        stateManager.SwitchRotation(false);

    }


    IEnumerator DrownOnDeath(int delay, int drownTime, int depth)
    {
        yield return new WaitForSeconds(delay);

        float timer = 0;
        while(timer < drownTime)
        {
            timer += Time.deltaTime;
            stateManager.transform.position -= new Vector3(0,depth*Time.deltaTime/drownTime,0);
            yield return null;
        }
        GameObject.Destroy(stateManager.gameObject);
        yield break;
    }
}
