using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAction {

    public struct Action
    {
        public string actionName;
        public int weight;
        public List<KeyValuePair<string, bool>> preconditions;
        public int amountOfPreConditionsNeeded;
        public List<KeyValuePair<string, bool>> effects;
    };

    public GameObject agent;
    public Action action;

    public virtual void MakeAction()
    {

    }

    public virtual void PlayAction()
    {

    }

    public virtual bool requiresInRange()
    {
        return false;
    }

    virtual public bool isDone()
    {
        return false;
    }

    virtual public void UpdateState()
    {

    }

    virtual public void WhichAgent(GameObject setAgent) //This is the agent doing the action
    {
        agent = setAgent;
    }


    

   
}
