using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {
    public List<GameObject> teamMembers = new List<GameObject>();

    public List<AgentData> agentData = new List<AgentData>();
  

    public List<Sensing> agentSensing = new List<Sensing>();


    public List<KeyValuePair<AIGoals.Goal, bool>> goals;
    public List<KeyValuePair<string, bool>> states;

    public List<AIAction> actions = new List<AIAction>();

    private int allMembersBusy = -1000;
    private int chosenTeamMember = 0;

    // Use this for initialization
    void Start () {
        
        goals = GetComponent<AIGoals>().goals;
        states = GetComponent<AIState>().state;
	}

    // Update is called once per frame
    void Update()
    {
        if(teamMembers == null) //Aka, if we haven't found the game objects yet, since we can't find it through the start function.
        {
            FindGameObject();
            AddActions();
        }

        for(int i = 0; i < goals.Count; i++) //Go Through the Goals
        {
            if (IsValid(goals[i]))
            {
                chosenTeamMember = ChooseTeamMember();
                if(chosenTeamMember != allMembersBusy)
                {
                    //Make a plan to make AI "chosenTeamMember" achive goals[i]
                    List<AIAction> foo = new List<AIAction>(GetComponent<AIPlanner>().GeneratePlan(teamMembers[0], goals[i]));
                    foo[0].PlayAction(teamMembers[0]);
                }
                else
                {
                    //All teamMembers busy, make a default 
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

    void AddActions()
    {
        actions.Add(new MoveToAllyBase());
        actions.Add(new MoveToEnemyBase());
        actions.Add(new MoveToLeft());
        actions.Add(new MoveToRight());
        actions.Add(new MoveToMiddle());
        actions.Add(new HaveEnemyFlag());

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
