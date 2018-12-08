using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveEnemyFlag : AIAction
{

    // Use this for initialization
    string enemyTeam;

    public override void MakeAction()
    {
        action.preconditions = new List<KeyValuePair<string, bool>>();
        action.effects = new List<KeyValuePair<string, bool>>();
        action.actionName = "HaveEnemyFlag";
        action.weight = 1;
        action.amountOfPreConditionsNeeded = 1;
        action.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlEnemyBase", true));
        action.effects.Add(new KeyValuePair<string, bool>("AnyAgentHaveEnemyFlag", true));

         
    }

    public override void PlayAction()
    {
        enemyTeam = WhichTeam(agent);
        GameObject gameObjectToPickUp = agent.GetComponent<Sensing>().GetObjectsInViewByTag("Flag")[0];

        if(!agent.GetComponentInChildren<Sensing>().IsItemInReach(gameObjectToPickUp))
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

    public override bool isDone()
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
