using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMiddle : AIAction
{

    Action moveToMiddle;
    // Use this for initialization
    Vector3 blueMiddle = new Vector3(-11.5f, 0, 0.67f);
    Vector3 redMiddle = new Vector3(11.5f, 0, 0.21f);

    public override void MakeAction()
    {

    }

    public override void PlayAction(GameObject agent)
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

    public override bool isDone(GameObject agent)
    {
        return false;
    }
}
