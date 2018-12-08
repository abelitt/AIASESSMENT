using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRight : AIAction
{

    // Use this for initialization


    public override void MakeAction()
    {
        action.preconditions = new List<KeyValuePair<string, bool>>();
        action.effects = new List<KeyValuePair<string, bool>>();
        action.actionName = "MoveToRight";
        action.weight = 1;
        action.amountOfPreConditionsNeeded = 1;
        action.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlRight", false));
        action.effects.Add(new KeyValuePair<string, bool>("AnyAgentControlRight", true));
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
