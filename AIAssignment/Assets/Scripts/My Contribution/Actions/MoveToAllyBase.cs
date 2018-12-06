using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAllyBase : AIAction
{
    
    Action moveToAllyBase;
    // Use this for initialization


    public override void MakeAction()
    {

    }

    public override void PlayAction(GameObject agent)
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

    public override bool isDone(GameObject agent)
    {
        return false;
    }
}
