using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAction {

    public struct Action
    {
        public string ActionName;
        public int weight; 
        public List<KeyValuePair<string, bool>> preconditions;
        public int amountOfPreConditionsNeeded;
        public List<KeyValuePair<string, bool>> effects;
    };

   

    public virtual void MakeAction()
    {

    }

    public virtual void PlayAction(GameObject agent)
    {

    }

    public virtual bool requiresInRange()
    {
        return false;
    }

    virtual public bool isDone(GameObject agent)
    {
        return false;
    }

    virtual public void UpdateState()
    {

    }


    

   
}
