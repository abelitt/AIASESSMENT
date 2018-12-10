using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : AIAction
{

    // Use this for initialization

    public override void MakeAction()
    {
        action.preconditions = new List<KeyValuePair<string, bool>>();
        action.effects = new List<KeyValuePair<string, bool>>();
        action.actionName = "Attack";
        action.weight = 2;
        action.amountOfPreConditionsNeeded = 1;
       // action.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlLeft", false));
        //action.effects.Add(new KeyValuePair<string, bool>("AnyAgentControlLeft", true));
    }

    public override void PlayAction()
    {
        agent.GetComponent<AgentActions>().MoveTo(secondaryGameObject);
        agent.GetComponent<AgentActions>().AttackEnemy(secondaryGameObject);
    }

    public override bool RequireSecondaryObject()
    {
        return true;
    }

    public override bool isDone()
    {
        if(secondaryGameObject)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    
}

