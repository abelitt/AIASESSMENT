using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlanner {

    public List<AIAction> actions = new List<AIAction>();
    List<GameObject> objectsAgentSee = new List<GameObject>();
    // Use this for initialization
    void Start () {
	}

    void AddMainActions()
    {
        actions.Clear();
        actions.Add(new MoveToAllyBase());
        actions.Add(new MoveToEnemyBase());
        actions.Add(new MoveToLeft());
        actions.Add(new MoveToRight());
        actions.Add(new MoveToMiddle());
        actions.Add(new HaveEnemyFlag());

        for(int i = 0; i < actions.Count; i++)
        {
            actions[i].MakeAction();
        }

    }

    public List<AIAction> GeneratePlan(GameObject agent, KeyValuePair<AIGoals.Goal, bool> goal)
    {
        AddMainActions();

        List<KeyValuePair<string, bool>> goalPreconditions = new List<KeyValuePair<string, bool>>(goal.Key.preconditions);

        List<AIAction> actionsToConsider = new List<AIAction>();
 
        for (int i = 0; i < actions.Count; i++) //Go Through all Actions
        {
            Debug.Log(goal.Key.goalName);
            int amountOfPreConidtionsComplete = 0;
            for (int k = 0; k < goalPreconditions.Count; k++) // go through the goals preconditions
            {
                for(int p = 0; p < actions[i].action.preconditions.Count; p++) //check the actions preconditions
                {
                    if (actions[i].action.preconditions[p].Key == goalPreconditions[k].Key) //Is the pre condition name same as the goal name
                    {
                        if(actions[i].action.preconditions[p].Value == goalPreconditions[k].Value) //Do they share the same value 
                        {
                            amountOfPreConidtionsComplete += 1; //Add to the amount of preconditions needed to complete this 
                        }  
                    }
                    if (amountOfPreConidtionsComplete == goal.Key.amountOfPreConditionsNeeded)
                    {
                        actions[i].WhichAgent(agent);
                        actionsToConsider.Add(actions[i]);
                        return actionsToConsider;
                    }
                }
               
            }

        }

        if(actionsToConsider.Count == 1)
        {
            return actionsToConsider;
        }
        else
        {
            //Sort the ideas
        }

        //goal.Key.effects;
        return actions; //The default for now 
    }

    public List<AIAction> ChangeOfPlan(List<AIAction> plan, GameObject agent)
    {
        objectsAgentSee = agent.GetComponentInChildren<Sensing>().GetObjectsInViewByTag("Collectable");
        if(objectsAgentSee.Count > 0)
        {
            //AddAction to pick up object
        }

        if(agent.tag == "Blue Team")
        {
            objectsAgentSee = agent.GetComponentInChildren<Sensing>().GetObjectsInViewByTag("Red Team");
        }
        else
        {
            objectsAgentSee = agent.GetComponentInChildren<Sensing>().GetObjectsInViewByTag("Blue Team");
        }

        if (objectsAgentSee.Count > 0)
        {
            for (int i = 0; i < objectsAgentSee.Count; i++)
            {
                plan.Insert(0, new Attack());
                plan[0].WhichAgent(agent);
                plan[0].SetSecondaryGameObject(objectsAgentSee[i]);
            }
            
        }

        //if()

        return plan;
    }
}
