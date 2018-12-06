using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRight : AIAction
{

    Action moveToRight;
    // Use this for initialization


    public override void MakeAction()
    {

    }

    public override void PlayAction(GameObject agent)
    {
        agent.GetComponent<AgentActions>().MoveTo(GameObject.Find("HealthKitSpawner"));
    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool isDone(GameObject agent)
    {
        if (GameObject.Find("HealthKitSpawner").transform.position.x == agent.transform.position.x && GameObject.Find("HealthKitSpawner").transform.position.z == agent.transform.position.z)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
