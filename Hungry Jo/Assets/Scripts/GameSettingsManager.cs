using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsManager : MonoBehaviour
{
    public static GameSettingsManager instance;

   public float happinessDecrease = 0.01f;
    public float happinessIncrease = 0.01f;

    public int giveDrinkHappinessIncrease = 30;

    public int angryThreshold = 15;
    public float angryEffectRadius = 100;
    public float angryEffectStrength = 1; //a value of 1 will additionally lower it at the same rate as they are normally lowered when waiting

    public float DistanceToEnemyGangToAnger = 5; 


    private void Start()
    {
        if(instance != null) Destroy(instance);
        instance = this;
    }


}
