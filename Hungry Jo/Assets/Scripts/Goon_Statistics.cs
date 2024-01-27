using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon_Statistics : MonoBehaviour
{
    [SerializeField] public enum Colour
    {
        Red, Green, Blue, Police
    }

    [SerializeField] int _maxHappiness = 100;
    [SerializeField] float _currentHappiness;
    public float CurrentHappiness { get { return _currentHappiness; } }

    [SerializeField]float happinessLowerAmount = 0.1f;
    [SerializeField]float happinessRaiseAmount = 0.1f;

    [SerializeField] bool lowerHappiness = true;


    private void Update()
    {
       
    }
    private void OnEnable()
    {
        _currentHappiness = _maxHappiness*0.5f;
    }

    public void LowerHappiness(float multiplier)
    {
        if(lowerHappiness)
        _currentHappiness -= (happinessLowerAmount * multiplier);
    }

    public void RaiseHappiness(float multiplier)
    {

        _currentHappiness += (happinessRaiseAmount * multiplier);
    }
}
