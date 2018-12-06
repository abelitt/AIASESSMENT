using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToEnemyBase : AIAction
{

    Action moveToEnemyBase;
    // Use this for initialization


    public override void MakeAction()
    {

    }

    public override void PlayAction(GameObject agent)
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

    public override bool isDone(GameObject agent)
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
