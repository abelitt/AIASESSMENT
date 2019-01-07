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
        int amountOfPreConidtionsComplete = 0;
        List<KeyValuePair<string, bool>> goalPreconditions = new List<KeyValuePair<string, bool>>(goal.Key.preconditions);

        List<AIAction> actionsToConsider = new List<AIAction>();
 
        for (int i = 0; i < actions.Count; i++) //Go Through all Actions
        {
            Debug.Log(goal.Key.goalName);
            
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
                    if (amountOfPreConidtionsComplete == goal.Key.amountOfPreConditionsNeeded) //If it means the goals and actions preconditions
                    {
                        actions[i].WhichAgent(agent); //Set who is using this action
                        actionsToConsider.Add(actions[i]); 
                        return actionsToConsider; //This was added here as a result of acknowledging that this planner will only allow 1 action through
                    }
                }
               
            }

        }

        /*
        if (actionsToConsider.Count == 1) //If there is only 1 aciton in plan 
        {
            return actionsToConsider;
        }
        else //More than 1 thing to consider
        {
            //Sort the ideas with A* 
        }
        */
        return actionsToConsider; //The default for now 
        
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

        if (objectsAgentSee.Count > 0) //if this agent can see somone
        {
            for (int i = 0; i < objectsAgentSee.Count; i++) 
            {
                plan.Insert(0, new Attack()); //attack this AI
                plan[0].WhichAgent(agent);
                plan[0].SetSecondaryGameObject(objectsAgentSee[i]);
            }
            
        }

        //if()

        return plan;
    }
}
