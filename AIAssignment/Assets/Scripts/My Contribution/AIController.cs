using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {
    private List<GameObject> teamMembers = new List<GameObject>();

    private List<AgentData> agentData = new List<AgentData>();
  

    private List<Sensing> agentSensing = new List<Sensing>();


    private List<KeyValuePair<AIGoals.Goal, bool>> goals;
    private List<KeyValuePair<string, bool>> states;
    private AIPlanner planner;
    private AIGoals goalMaker;
    private AIState stateMaker;
    private List<List<AIAction>> plan = new List<List<AIAction>>();

    private int allMembersBusy = -1000;
    private int chosenTeamMember = 0;
    private static int CURRENT_ACTION = 0;
    private static int AMOUNT_OF_TEAM_MEMBERS = 3; 
    
    // Use this for initialization
    void Start () {
        AIGoals goalMaker = new AIGoals();
        goalMaker.CreateGoals();
        goals = goalMaker.GetGoals();
        goalMaker = null;

        stateMaker = new AIState();
        stateMaker.MakeStates();
        states = stateMaker.state;
        stateMaker = null;
	}

    // Update is called once per frame
    void Update()
    {
        if (teamMembers.Count < 3) //At the start this will call so that we can find the game objects
        {
            FindGameObject();
        }

        for (int i = 0; i < teamMembers.Count; i++) //Checks If any AI is Dead
        {
            if(teamMembers[i] == null) //If any AI is dead
            {
                FindGameObject();
            }
        }

        for(int i = 0; i < goals.Count; i++) //Go Through the Goals
        {
            if (IsValid(goals[i])) //Check if the Goal is worth going for 
            {
                chosenTeamMember = ChooseTeamMember(); //choose a team memeber
                if (chosenTeamMember != allMembersBusy) //If there isn't a team member that isn't busy
                {
                    planner = new AIPlanner(); //Make a new plan
                    teamMembers[chosenTeamMember].GetComponent<AI>().aiBusy = true; //Set the team member to busy
                    plan.Add(new List<AIAction>(planner.GeneratePlan(teamMembers[chosenTeamMember], goals[i]))); //Generate a plan for the AI to do 
                    
                    planner = null; // removes the plan so that we can make new plans
                }
                else //If all team members are currently busy 
                {
                    for(int q = 0; q < plan.Count; q++) //Go through the different plans currently made
                    {
                        if(plan[q][CURRENT_ACTION].isDone()) //is the current action of that plan done
                        {
                            Debug.Log(plan[q][CURRENT_ACTION].action.actionName + " IS DONE"); //The plan is done, now change the values and stuff
                            plan[q][CURRENT_ACTION].UpdateState(states); //Update the state
                            if (plan[q].Count == 1) //If this is the final step to the plan
                            {
                                plan[q][CURRENT_ACTION].agent.GetComponent<AI>().aiBusy = false; //Set the AI to no longer busy
                                plan.RemoveAt(q); //remove the plan so that since we don't need to update it again
                                //q -= 1; //Since everything on the list will now go down one, this allows the code to still run the other plans
                            }
                           else
                            {
                                plan[q].RemoveAt(CURRENT_ACTION); //remove that action from the plan, now the next CURRENT_ACTION will be played. 
                            } 
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
        teamMembers.Clear();
        string whichTeam;
        if (gameObject.tag == "Blue Team")
        {
            whichTeam = "Blue";
        }
        else
        {
            whichTeam = "Red";
        }
      
       for(int i = 0; i < AMOUNT_OF_TEAM_MEMBERS; i++)
        {
            teamMembers.Add(GameObject.Find(whichTeam + " Team Member " + (i+1).ToString()));
            if(teamMembers[i] == null)
            {
                teamMembers.RemoveAt(i);
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
