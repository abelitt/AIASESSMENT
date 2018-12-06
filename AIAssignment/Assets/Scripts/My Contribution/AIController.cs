using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {
    public GameObject TeamMember1;
    public GameObject TeamMember2;
    public GameObject TeamMember3;
    public AgentData AgentDataTeamMember1;
    public AgentData AgentDataTeamMember2;
    public AgentData AgentDataTeamMember3;
    public AgentActions AgentActionsTeamMember1;
    public AgentActions AgentActionsTeamMember2;
    public AgentActions AgentActionsTeamMember3;
    public Sensing AgentSensingTeamMember1;
    public Sensing AgentSensingTeamMember2;
    public Sensing AgentSensingTeamMember3;

    public List<KeyValuePair<AIGoals.Goal, bool>> goals;
    public List<KeyValuePair<string, bool>> states;

    //Debug
    public AIAction thing = new MoveToLeft();
    
    
    // Use this for initialization
    void Start () {
        
        goals = GetComponent<AIGoals>().goals;
        states = GetComponent<AIState>().state;
	}

    // Update is called once per frame
    void Update()
    {
        FindGameObject();
        for(int i = 0; i < goals.Count; i++)
        {
           
                if (IsValid(goals[i]))
                {
                    thing.PlayAction(TeamMember1);
                }

            

        }
        

    }
     
        

    void FindGameObject()
    {
        if (gameObject.tag == "Blue Team")
        {
            TeamMember1 = GameObject.Find("Blue Team Member 1");
            TeamMember2 = GameObject.Find("Blue Team Member 2");
            TeamMember3 = GameObject.Find("Blue Team Member 3");
            AgentActionsTeamMember1 = TeamMember1.GetComponent<AgentActions>();
            AgentActionsTeamMember2 = TeamMember2.GetComponent<AgentActions>();
            AgentActionsTeamMember3 = TeamMember3.GetComponent<AgentActions>();
            AgentDataTeamMember1 = TeamMember1.GetComponent<AgentData>();
            AgentDataTeamMember2 = TeamMember2.GetComponent<AgentData>();
            AgentDataTeamMember3 = TeamMember3.GetComponent<AgentData>();
            AgentSensingTeamMember1 = TeamMember1.GetComponentInChildren<Sensing>();
            AgentSensingTeamMember2 = TeamMember2.GetComponentInChildren<Sensing>();
            AgentSensingTeamMember3 = TeamMember3.GetComponentInChildren<Sensing>();
        }
    }

    bool IsValid(KeyValuePair<AIGoals.Goal, bool> goal)
    {
        int AmountOfPreConditionsMet = 0;

        for (int j = 0; j < states.Count; j++) //Go through states
        {
            for (int a = 0; a < goal.Key.preconditions.Count; a++) //else Check preconditions so we can compare them to the goals preconditions 
            {
                if (goal.Key.preconditions[a].Key == states[j].Key) //Is the precondition matching with the state that we are one (Are they the same string)
                {
                    if (goal.Key.preconditions[a].Value == states[j].Value) //If so, is the preconditions value (the boolean) the same
                    {
                        AmountOfPreConditionsMet += 1; //If so, add it to the counter 
                    }
                }

            }

            if (AmountOfPreConditionsMet >= goal.Key.amountOfPreConditionsNeeded) //If we have met enough of the preconditions then we are good to go with the goal. 
            {
                return true;
            }
        }
        return false;
    }
       
    }









/*   foo = AgentSensingTeamMember1.GetObjectsInView();
          /* if(foo != null)
           {
               if (foo[0].tag == "Collectable")
               {
                   AgentActionsTeamMember1.MoveTo(foo[0]);
               }
               else
               {
                   AgentActionsTeamMember1.MoveToRandomLocation();
               }
           }
           else
           {
               AgentActionsTeamMember1.MoveToRandomLocation();
           }
*/
