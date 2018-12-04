using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState: MonoBehaviour
{
    // Use this for initialization
    public List<KeyValuePair<string, bool>> state = new List<KeyValuePair<string, bool>>();

    void Start()
    {
        state.Add(new KeyValuePair<string, bool>("EnemyFlagInBase", true));
        state.Add(new KeyValuePair<string, bool>("Agent1HasEnemyFlag", true));
        state.Add(new KeyValuePair<string, bool>("Agent2HasEnemyFlag", true));
        state.Add(new KeyValuePair<string, bool>("Agent3HasEnemyFlag", true));
        state.Add(new KeyValuePair<string, bool>("EnemyHaveFlag", false));
        state.Add(new KeyValuePair<string, bool>("AnyAgentControlLeftPlanned", true));
        state.Add(new KeyValuePair<string, bool>("AnyAgentControlRightPlanned", true));
        state.Add(new KeyValuePair<string, bool>("AnyAgentControlMiddlePlanned", true));

        state.Add(new KeyValuePair<string, bool>("Agent1ControlLeft", true));
        state.Add(new KeyValuePair<string, bool>("Agent2ControlLeft", true));
        state.Add(new KeyValuePair<string, bool>("Agent3ControlLeft", true));
        state.Add(new KeyValuePair<string, bool>("Agent1ControlRight", true));
        state.Add(new KeyValuePair<string, bool>("Agent2ControlRight", true));
        state.Add(new KeyValuePair<string, bool>("Agent3ControlRight", true));
        state.Add(new KeyValuePair<string, bool>("Agent1ControlMiddle", true));
        state.Add(new KeyValuePair<string, bool>("Agent2ControlMiddle", true));
        state.Add(new KeyValuePair<string, bool>("Agent3ControlMiddle", true));
        state.Add(new KeyValuePair<string, bool>("Agent1ControlAllyBase", true));
        state.Add(new KeyValuePair<string, bool>("Agent2ControlAllyBase", true));
        state.Add(new KeyValuePair<string, bool>("Agent3ControlAllyBase", true));
        state.Add(new KeyValuePair<string, bool>("Agent1ControlEnemyBase", true));
        state.Add(new KeyValuePair<string, bool>("Agent2ControlEnemyBase", true));
        state.Add(new KeyValuePair<string, bool>("Agent3ControlEnemyBase", true));
        state.Add(new KeyValuePair<string, bool>("Agent1AgentPowerUp", true));
        state.Add(new KeyValuePair<string, bool>("Agent2AgentPowerUp", true));
        state.Add(new KeyValuePair<string, bool>("Agent3AgentPowerUp", true));
        state.Add(new KeyValuePair<string, bool>("Agent1HealthLow", false));
        state.Add(new KeyValuePair<string, bool>("Agent2HealthLow", false));
        state.Add(new KeyValuePair<string, bool>("Agent3HealthLow", false));


        state.Add(new KeyValuePair<string, bool>("DoesEnemyHaveFlag", false));
        state.Add(new KeyValuePair<string, bool>("EnemyFlagInBase", true));
        state.Add(new KeyValuePair<string, bool>("AllyFlagInBase", true));
        state.Add(new KeyValuePair<string, bool>("AnyAgentHaveEnemyFlag", true));
        state.Add(new KeyValuePair<string, bool>("AnyAgentControlEnemyBase", true));

        state.Add(new KeyValuePair<string, bool>("AnyAgentControlLeft", true));
        state.Add(new KeyValuePair<string, bool>("AnyAgentControlRight", true));
        state.Add(new KeyValuePair<string, bool>("AnyAgentControlMiddle", true));
        state.Add(new KeyValuePair<string, bool>("AnyAgentControlAllyBase", true));

        state.Add(new KeyValuePair<string, bool>("AnyAgentPowerUp", true));
        state.Add(new KeyValuePair<string, bool>("AnyAgentHealthLow", false));
    }


    // Update is called once per frame
    void Update()
    {

    }

}