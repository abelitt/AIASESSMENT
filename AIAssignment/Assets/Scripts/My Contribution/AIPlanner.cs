using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlanner : MonoBehaviour {

    public List<AIAction> actions = new List<AIAction>();
	// Use this for initialization
	void Start () {
        AddActions();
	}

    void AddActions()
    {
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
        List<KeyValuePair<string, bool>> goalPreconditions = goal.Key.preconditions;

        List<AIAction> actionsToConsider = new List<AIAction>();

        

        for(int i = 0; i < actions.Count; i++) //Go Through all Actions
        {
            int amountOfPreConidtionsNeeded = 0;
            for (int k = 0; k < goalPreconditions.Count; k++) // go through the goals preconditions
            {
                for(int p = 0; p < actions[i].action.preconditions.Count; p++) //check the actions preconditions
                {
                    if (actions[i].action.preconditions[p].Key == goalPreconditions[k].Key) //WARNING [ACTION NAME NEEDS TO CHANGE TO PRECONDITIONS]
                    {
                        if(actions[i].action.preconditions[p].Value == goalPreconditions[k].Value)
                        {
                            amountOfPreConidtionsNeeded += 1;
                        }  
                    }
                    if (actions[i].action.amountOfPreConditionsNeeded == goal.Key.amountOfPreConditionsNeeded)
                    {
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

        }

        //goal.Key.effects;
        return actions; //This should return a plan of various actions 
    }
}
