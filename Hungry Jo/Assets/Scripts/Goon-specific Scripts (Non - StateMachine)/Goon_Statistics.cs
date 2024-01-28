using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon_Statistics : MonoBehaviour
{
    [SerializeField] public enum Colour
    {
        Red, Green, Blue, Police
    }

    [SerializeField] private Goon_Statistics.Colour _gangColour;

    public Colour GoonColor;

    [SerializeField] int _maxHappiness = 100;
    [SerializeField] float _currentHappiness;
    public float CurrentHappiness { get { return _currentHappiness; } }

    [SerializeField]float happinessLowerAmount = 0.00001f;
    [SerializeField]float happinessRaiseAmount = 0.00001f;

    [SerializeField] float _musicColourMatchModifier = 0.9f;

    [SerializeField] bool lowerHappiness = true;

    [SerializeField] public bool loseReputationOnThrowOut = true;
    [SerializeField] public bool hasDrink = false;


    public void SetTabletDate()
    {
        Tablet.InteractedGoonGangName = _gangColour.ToString();

        if (_gangColour == Colour.Red)
        {
            Tablet.InteractedGoonMusicName = "Favorite Music: Rock";
        }
        else if (_gangColour == Colour.Green)
        {
            Tablet.InteractedGoonMusicName = "Favorite Music: Disco";
        }
        else if (_gangColour == Colour.Blue)
        {
            Tablet.InteractedGoonMusicName = "Favorite Music: Jazz";
        }
        else
        {
            Tablet.InteractedGoonMusicName = "Favorite Music: Who cares?";
        }

        Tablet.InteractedGoonMoodValue = _currentHappiness / _maxHappiness;
    }

    private void Update()
    {
        if ((int)Jukebox.singleton._musicGenrePlaying == (int)_gangColour)
        {
            RaiseHappiness(_musicColourMatchModifier);
            //Debug.Log("Happy!");
        }

       Mathf.Clamp(_currentHappiness, 0, _maxHappiness);
    }
    private void Start()
    {
        GoonColor = _gangColour;

        _currentHappiness = 100;
    }

    public void LowerHappiness(float multiplier)
    {
        if(lowerHappiness)
        _currentHappiness -= (GameSettingsManager.instance.happinessDecrease * multiplier);
    }

    public void RaiseHappiness(float multiplier)
    {

        _currentHappiness += (GameSettingsManager.instance.happinessIncrease * multiplier);
    }

    


}
