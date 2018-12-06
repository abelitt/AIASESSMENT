using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveEnemyFlag : AIAction
{

    Action haveEnemyFlag;
    // Use this for initialization
    string enemyTeam;

    public override void MakeAction()
    {

    }

    public override void PlayAction(GameObject agent)
    {
        enemyTeam = WhichTeam(agent); 

        if(!agent.GetComponentInChildren<Sensing>().IsItemInReach(GameObject.Find(enemyTeam + " Flag")))
        {
            agent.GetComponent<AgentActions>().MoveTo(GameObject.Find(enemyTeam + " Flag"));
        }
        else
        {
            agent.GetComponent<AgentActions>().CollectItem(GameObject.Find(enemyTeam + " Flag"));
        }
        
      

    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool isDone(GameObject agent)
    {
        enemyTeam = WhichTeam(agent);

        if (GameObject.Find(enemyTeam + " Flag").transform.position.x == agent.transform.position.x && GameObject.Find(enemyTeam + " Flag").transform.position.z == agent.transform.position.z)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string WhichTeam(GameObject agent)
    {
        if (agent.tag == "Blue Team")
        {
            return "Red";
        }
        else
        {
           return "Blue";
        }
    }
}
