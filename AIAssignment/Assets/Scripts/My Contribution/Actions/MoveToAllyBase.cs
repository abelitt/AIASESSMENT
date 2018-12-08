using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAllyBase : AIAction
{
    
    // Use this for initialization


    public override void MakeAction()
    {
        action.preconditions = new List<KeyValuePair<string, bool>>();
        action.effects = new List<KeyValuePair<string, bool>>();
        action.actionName = "MoveToAllyBase";
        action.weight = 1;
        action.amountOfPreConditionsNeeded = 1;
        action.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentHaveEnemyFlag", true));
        action.effects.Add(new KeyValuePair<string, bool>("AnyAgentControlAllyBase", true));
    }

    public override void PlayAction()
    {
        if(agent.tag == "Blue Team")
        {
            agent.GetComponent<AgentActions>().MoveTo(GameObject.Find("Blue Base"));
        }
        else
        {
            agent.GetComponent<AgentActions>().MoveTo(GameObject.Find("Red Base"));
        }
       
    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool isDone()
    {
        return false;
    }
}
