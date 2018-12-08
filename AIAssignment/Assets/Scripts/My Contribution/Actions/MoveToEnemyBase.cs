using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToEnemyBase : AIAction
{

    // Use this for initialization


    public override void MakeAction()
    {
        action.preconditions = new List<KeyValuePair<string, bool>>();
        action.effects = new List<KeyValuePair<string, bool>>();
        action.actionName = "MoveToEnemyBase";
        action.weight = 1;
        action.amountOfPreConditionsNeeded = 2;
        action.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlLeft", true));
        action.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlRight", true));
        action.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlMiddle", true));
        action.effects.Add(new KeyValuePair<string, bool>("AnyAgentHaveEnemyFlag", true));
    }

    public override void PlayAction()
    {
        if (agent.tag == "Blue Team")
        {
            agent.GetComponent<AgentActions>().MoveTo(GameObject.Find("Red Base"));
        }
        else
        {
            agent.GetComponent<AgentActions>().MoveTo(GameObject.Find("Blue Base"));
        }

    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool isDone()
    {
        if (agent.tag == "Blue Team")
        {
            if (GameObject.Find("Red Base").transform.position.x == agent.transform.position.x && GameObject.Find("Red Base").transform.position.z == agent.transform.position.z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (GameObject.Find("Blue Base").transform.position.x == agent.transform.position.x && GameObject.Find("Blue Base").transform.position.z == agent.transform.position.z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
      
    }
}
