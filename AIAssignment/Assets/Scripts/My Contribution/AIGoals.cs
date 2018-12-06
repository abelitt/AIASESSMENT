using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGoals: MonoBehaviour {

    public struct Goal
    {
        public string goalName;
        public List<KeyValuePair<string, bool>> preconditions;
        public int amountOfPreConditionsNeeded;
        public List<KeyValuePair<string, bool>> effects;
    };

    public List<KeyValuePair<Goal, bool>> goals; 
	void Start () {

        CreateGoals();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
       
    void CreateGoals()
    {
        Goal enemyFlagInBase = new Goal();
        enemyFlagInBase.goalName = "EnemyFlagInBase";
        enemyFlagInBase.preconditions = new List<KeyValuePair<string, bool>>();
        enemyFlagInBase.effects = new List<KeyValuePair<string, bool>>();
        enemyFlagInBase.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentHaveEnemyFlag", true));
        enemyFlagInBase.amountOfPreConditionsNeeded = 1;
        enemyFlagInBase.effects.Add(new KeyValuePair<string, bool>("EnemyFlagInBase", true));


        Goal allyFlagInBase = new Goal();
        allyFlagInBase.goalName = "AllyFlagInBase";
        allyFlagInBase.preconditions = new List<KeyValuePair<string, bool>>();
        allyFlagInBase.effects = new List<KeyValuePair<string, bool>>();
        allyFlagInBase.preconditions.Add(new KeyValuePair<string, bool>("AllyFlagInBase", false));
        allyFlagInBase.amountOfPreConditionsNeeded = 1;
        allyFlagInBase.effects.Add(new KeyValuePair<string, bool>("AllyFlagInBase", true));

        Goal anyAgentHaveFlag = new Goal();
        anyAgentHaveFlag.goalName = "AnyAgentHaveFlag";
        anyAgentHaveFlag.preconditions = new List<KeyValuePair<string, bool>>();
        anyAgentHaveFlag.effects = new List<KeyValuePair<string, bool>>();
        anyAgentHaveFlag.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlEnemyBase", true));
        anyAgentHaveFlag.amountOfPreConditionsNeeded = 1;
        anyAgentHaveFlag.effects.Add(new KeyValuePair<string, bool>("AnyAgentHaveFlag", true));

        Goal anyAgentControlEnemyBase = new Goal();
        anyAgentControlEnemyBase.goalName = "AnyAgentControlLeft";
        anyAgentControlEnemyBase.preconditions = new List<KeyValuePair<string, bool>>();
        anyAgentControlEnemyBase.effects = new List<KeyValuePair<string, bool>>();
        anyAgentControlEnemyBase.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlLeft", true));
        anyAgentControlEnemyBase.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlMiddle", true));
        anyAgentControlEnemyBase.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlRight", true));
        anyAgentControlEnemyBase.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentPowerUp", true));
        anyAgentControlEnemyBase.amountOfPreConditionsNeeded = 2;
        anyAgentControlEnemyBase.effects.Add(new KeyValuePair<string, bool>("AnyAgentHaveFlag", true));

        Goal anyAgentControlLeft = new Goal();
        anyAgentControlLeft.preconditions = new List<KeyValuePair<string, bool>>();
        anyAgentControlLeft.effects = new List<KeyValuePair<string, bool>>();
        anyAgentControlLeft.goalName = "AnyAgentControlLeft";
        anyAgentControlLeft.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlLeftPlanned", false));
        anyAgentControlLeft.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlLeft", false));
        anyAgentControlLeft.amountOfPreConditionsNeeded = 2;
        anyAgentControlLeft.effects.Add(new KeyValuePair<string, bool>("AnyAgentControlLeft", true));

        Goal anyAgentControlRight = new Goal();
        anyAgentControlRight.preconditions = new List<KeyValuePair<string, bool>>();
        anyAgentControlRight.effects = new List<KeyValuePair<string, bool>>();
        anyAgentControlRight.goalName = "AnyAgentControlRight";
        anyAgentControlRight.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlRightPlanned", false));
        anyAgentControlRight.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlRight", false));
        anyAgentControlRight.amountOfPreConditionsNeeded = 2;
        anyAgentControlRight.effects.Add(new KeyValuePair<string, bool>("AnyAgentControlRight", true));

        Goal anyAgentControlMiddle = new Goal();
        anyAgentControlMiddle.preconditions = new List<KeyValuePair<string, bool>>();
        anyAgentControlMiddle.effects = new List<KeyValuePair<string, bool>>();
        anyAgentControlMiddle.goalName = "AnyAgentControlMiddle";
        anyAgentControlMiddle.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlMiddlePlanned", false));
        anyAgentControlMiddle.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlMiddle", false));
        anyAgentControlMiddle.amountOfPreConditionsNeeded = 2;
        anyAgentControlMiddle.effects.Add(new KeyValuePair<string, bool>("AnyAgentControlMiddle", true));

        Goal anyAgentControlAllyBase = new Goal();
        anyAgentControlAllyBase.preconditions = new List<KeyValuePair<string, bool>>();
        anyAgentControlAllyBase.effects = new List<KeyValuePair<string, bool>>();
        anyAgentControlAllyBase.goalName = "AnyAgentControlAllyBase";
        anyAgentControlAllyBase.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlAllyBasePlanned", false));
        anyAgentControlAllyBase.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlLeft", true));
        anyAgentControlAllyBase.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlMiddle", true));
        anyAgentControlAllyBase.preconditions.Add(new KeyValuePair<string, bool>("AnyAgentControlRight", true));
        anyAgentControlAllyBase.amountOfPreConditionsNeeded = 2;
        anyAgentControlAllyBase.effects.Add(new KeyValuePair<string, bool>("AnyAgentControlAllyBase", true));

        goals = new List<KeyValuePair<Goal, bool>>();
        goals.Add(new KeyValuePair<Goal, bool>(enemyFlagInBase, true));
        goals.Add(new KeyValuePair<Goal, bool>(allyFlagInBase, true));
        goals.Add(new KeyValuePair<Goal, bool>(anyAgentHaveFlag, true));
        goals.Add(new KeyValuePair<Goal, bool>(anyAgentControlEnemyBase, true));
        goals.Add(new KeyValuePair<Goal, bool>(anyAgentControlLeft, true));
        goals.Add(new KeyValuePair<Goal, bool>(anyAgentControlRight, true));
        goals.Add(new KeyValuePair<Goal, bool>(anyAgentControlMiddle, true));
        goals.Add(new KeyValuePair<Goal, bool>(anyAgentControlAllyBase, true));


    }
}


//FOOGOALS.Add(new KeyValuePair<string, bool>("DoesEnemyHaveFlag", false));   
//FOOGOALS.Add(new KeyValuePair<string, bool>("AnyAgentPowerUp", true));
//FOOGOALS.Add(new KeyValuePair<string, bool>("AnyAgentHealthLow", false)); 