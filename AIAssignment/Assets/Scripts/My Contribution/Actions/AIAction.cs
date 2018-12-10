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
    public GameObject secondaryGameObject;

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

    virtual public void UpdateState(List<KeyValuePair<string, bool>> states)
    {
        Debug.Log(action.actionName);
        for (int i = 0; i < action.effects.Count; i++)
        {
            for (int k = 0; k < states.Count; k++)
            {
                if (states[k].Key == action.effects[i].Key)
                {
                    states[k] = new KeyValuePair<string, bool>(action.effects[i].Key, action.effects[i].Value);
                }
            }
        }
    }

    virtual public void WhichAgent(GameObject setAgent) //This is the agent doing the action
    {
        agent = setAgent;
    }

    virtual public bool RequireSecondaryObject()
    {
        return false;
    }

    virtual public void SetSecondaryGameObject(GameObject input)
    {
        secondaryGameObject = input;
    }





}
