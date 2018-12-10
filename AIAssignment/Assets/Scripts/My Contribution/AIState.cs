using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState {
    // Use this for initialization
    public List<KeyValuePair<string, bool>> state = new List<KeyValuePair<string, bool>>();

    public void MakeStates()
    {
        state.Add(new KeyValuePair<string, bool>("EnemyFlagInBase", false));
        state.Add(new KeyValuePair<string, bool>("AllyFlagInBase", true));
        state.Add(new KeyValuePair<string, bool>("AnyAgentHaveEnemyFlag", false));
        state.Add(new KeyValuePair<string, bool>("AnyAgentControlEnemyBase", false));
        state.Add(new KeyValuePair<string, bool>("AnyAgentControlLeft", false));
        state.Add(new KeyValuePair<string, bool>("AnyAgentControlRight", false));
        state.Add(new KeyValuePair<string, bool>("AnyAgentControlMiddle", false));
        state.Add(new KeyValuePair<string, bool>("AnyAgentControlAllyBase", false));

        state.Add(new KeyValuePair<string, bool>("AnyAgentPowerUp", false));
        state.Add(new KeyValuePair<string, bool>("AnyAgentHealthLow", false));

        state.Add(new KeyValuePair<string, bool>("Agent1HasEnemyFlag", false));
        state.Add(new KeyValuePair<string, bool>("Agent2HasEnemyFlag", false));
        state.Add(new KeyValuePair<string, bool>("Agent3HasEnemyFlag", false));

        state.Add(new KeyValuePair<string, bool>("Agent1ControlLeft", false));
        state.Add(new KeyValuePair<string, bool>("Agent2ControlLeft", false));
        state.Add(new KeyValuePair<string, bool>("Agent3ControlLeft", false));
        state.Add(new KeyValuePair<string, bool>("Agent1ControlRight", false));
        state.Add(new KeyValuePair<string, bool>("Agent2ControlRight", false));
        state.Add(new KeyValuePair<string, bool>("Agent3ControlRight", false));
        state.Add(new KeyValuePair<string, bool>("Agent1ControlMiddle", false));
        state.Add(new KeyValuePair<string, bool>("Agent2ControlMiddle", false));
        state.Add(new KeyValuePair<string, bool>("Agent3ControlMiddle", false));
        state.Add(new KeyValuePair<string, bool>("Agent1ControlAllyBase", true));
        state.Add(new KeyValuePair<string, bool>("Agent2ControlAllyBase", true));
        state.Add(new KeyValuePair<string, bool>("Agent3ControlAllyBase", true));
        state.Add(new KeyValuePair<string, bool>("Agent1ControlEnemyBase", false));
        state.Add(new KeyValuePair<string, bool>("Agent2ControlEnemyBase", false));
        state.Add(new KeyValuePair<string, bool>("Agent3ControlEnemyBase", false));
        state.Add(new KeyValuePair<string, bool>("Agent1AgentPowerUp", false));
        state.Add(new KeyValuePair<string, bool>("Agent2AgentPowerUp", false));
        state.Add(new KeyValuePair<string, bool>("Agent3AgentPowerUp", false));
        state.Add(new KeyValuePair<string, bool>("Agent1HealthLow", false));
        state.Add(new KeyValuePair<string, bool>("Agent2HealthLow", false));
        state.Add(new KeyValuePair<string, bool>("Agent3HealthLow", false));
    }

    // Update is called once per frame
    void Update()
    {

    }


    void CreateStates()
    {
       


    }

}


 
 
