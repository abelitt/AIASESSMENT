using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMiddle : AIAction
{

    // Use this for initialization
    Vector3 blueMiddle = new Vector3(-11.5f, 0, 0.67f);
    Vector3 redMiddle = new Vector3(11.5f, 0, 0.21f);

    public override void MakeAction()
    {
        action.preconditions = new List<KeyValuePair<string, bool>>();
        action.effects = new List<KeyValuePair<string, bool>>();
        action.actionName = "MoveToMiddle";
        action.weight = 1;
        action.amountOfPreConditionsNeeded = 1;
        action.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlMiddle", false));
        action.effects.Add(new KeyValuePair<string, bool>("AnyAgentControlMiddle", true));
    }

    public override void PlayAction()
    {
        if(agent.tag == "Blue Team")
        {
            agent.GetComponent<AgentActions>().MoveTo(blueMiddle);
        }
        else
        {
            agent.GetComponent<AgentActions>().MoveTo(redMiddle);
        }
            

    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool isDone()
    {
        if(agent.tag == "Blue Team")
        {
            if((Vector3.Distance(blueMiddle, agent.transform.position) < 2)) 
            {
                return true;
            }
        }
        else
        {
            if ((Vector3.Distance(redMiddle, agent.transform.position) < 2))
            {
                return true;
            }
        }
        
        //otherwise...
        return false;
    }
}
