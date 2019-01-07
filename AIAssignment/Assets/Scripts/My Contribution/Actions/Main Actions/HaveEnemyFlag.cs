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
        if(!secondaryGameObject)
        {
            secondaryGameObject = GameObject.Find(enemyTeam + " Flag");
        }

        if(!agent.GetComponentInChildren<Sensing>().IsItemInReach(secondaryGameObject))
        {
            agent.GetComponent<AgentActions>().MoveTo(secondaryGameObject);
        }
        else
        {
            agent.GetComponent<AgentActions>().CollectItem(secondaryGameObject);
        }
        
      

    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool isDone()
    {
        enemyTeam = WhichTeam(agent);
        InventoryController foo = agent.GetComponentInChildren<InventoryController>();
        if (foo.GetItem(enemyTeam + " Flag"))
        {
            return true;
        }
        return false;

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
