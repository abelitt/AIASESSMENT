using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {
    public List<GameObject> teamMembers = new List<GameObject>();

    public List<AgentData> agentData = new List<AgentData>();
  

    public List<Sensing> agentSensing = new List<Sensing>();


    public List<KeyValuePair<AIGoals.Goal, bool>> goals;
    public List<KeyValuePair<string, bool>> states;

    public List<List<AIAction>> plan = new List<List<AIAction>>();
    private int allMembersBusy = -1000;
    private int chosenTeamMember = 0;
    private static int CURRENT_ACTION = 0;
    
    // Use this for initialization
    void Start () {
        
        goals = GetComponent<AIGoals>().goals;
        states = GetComponent<AIState>().state;
	}

    // Update is called once per frame
    void Update()
    {
        if(teamMembers.Count < 3) //Aka, if we haven't found the game objects yet, since we can't find it through the start function.
        {
            FindGameObject();
        }

        for(int i = 0; i < goals.Count; i++) //Go Through the Goals
        {
            if (IsValid(goals[i])) //Check if the Goal is worth going for 
            {
                chosenTeamMember = ChooseTeamMember(); //choose a team memeber
                if (chosenTeamMember != allMembersBusy) //If there isn't a team member that isn't busy
                {
                    teamMembers[chosenTeamMember].GetComponent<AI>().aiBusy = true; //Set the team member to busy
                    plan.Add(new List<AIAction>(GetComponent<AIPlanner>().GeneratePlan(teamMembers[chosenTeamMember], goals[i]))); //Generate a plan for the AI to do 
                }
                else //If all team members are currently busy 
                {
                    for(int q = 0; q < plan.Count; q++)
                    {
                        if(plan[q][CURRENT_ACTION].isDone())
                        {
                            Debug.Log(plan[q][CURRENT_ACTION].action.actionName + "ISDONE");
                        }
                    }
                    //Check all the current actions in the plan
                    //if the action is finished, remove action from the plan and move to next action
                    //change state to action effects
                    //if the plan is now empty, the AI is no longer busy
                    //All teamMembers busy, make a default 
                }

                if(plan.Count > 0) //If there is currently a plan
                {
                    for (int k = 0; k < plan.Count; k++) //go through all the plans
                    {
                        plan[k][CURRENT_ACTION].PlayAction(); //Play the first action of each plan. Once this action is complete it will be removed so they can play the next plan
                    }
                }
              
            }
        } 

    }
     
        

    void FindGameObject()
    {
        if (gameObject.tag == "Blue Team")
        {
            teamMembers.Add(GameObject.Find("Blue Team Member 1"));
            teamMembers.Add(GameObject.Find("Blue Team Member 2"));
            teamMembers.Add(GameObject.Find("Blue Team Member 3"));

            for (int i = 0; i < teamMembers.Count; i++)
            {
                agentData.Add(teamMembers[i].GetComponent<AgentData>());
                agentSensing.Add(teamMembers[i].GetComponentInChildren<Sensing>());

            }
        }
    }

    int ChooseTeamMember()
    {
        for(int i = 0; i < teamMembers.Count; i++)
        {
            if(teamMembers[i].GetComponent<AI>().aiBusy == false)
            {
                return i;
            }
        }
        return allMembersBusy;
    }

    bool IsValid(KeyValuePair<AIGoals.Goal, bool> goal)
    {
        int amountOfPreConditionsMet = 0;

        for (int j = 0; j < states.Count; j++) //Go through states
        {
            for (int a = 0; a < goal.Key.preconditions.Count; a++) //else Check preconditions so we can compare them to the goals preconditions 
            {
                if (goal.Key.preconditions[a].Key == states[j].Key) //Is the precondition matching with the state that we are one (Are they the same string)
                {
                    if (goal.Key.preconditions[a].Value == states[j].Value) //If so, is the preconditions value (the boolean) the same
                    {
                        amountOfPreConditionsMet += 1; //If so, add it to the counter 
                    }
                }

            }

            if (amountOfPreConditionsMet >= goal.Key.amountOfPreConditionsNeeded) //If we have met enough of the preconditions then we are good to go with the goal. 
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
