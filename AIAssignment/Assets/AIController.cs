using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {
    private GameObject TeamMember1;
    private GameObject TeamMember2;
    private GameObject TeamMember3;
    private AgentData AgentDataTeamMember1;
    private AgentData AgentDataTeamMember2;
    private AgentData AgentDataTeamMember3;
    private AgentActions AgentActionsTeamMember1;
    private AgentActions AgentActionsTeamMember2;
    private AgentActions AgentActionsTeamMember3;
    private Sensing AgentSensingTeamMember1;
    private Sensing AgentSensingTeamMember2;
    private Sensing AgentSensingTeamMember3;

    private List<KeyValuePair<AIGoals.Goal, bool>> goals;
    private List<KeyValuePair<string, bool>> states;

    //DEBUG
    List<GameObject> foo;
    // Use this for initialization
    void Start () {
        foo = new List<GameObject>();
        goals = GetComponent<AIGoals>().goals;
        states = GetComponent<AIState>().state;
	}

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < goals.Count; i++)
        {
            IsValid(goals[i]);
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
