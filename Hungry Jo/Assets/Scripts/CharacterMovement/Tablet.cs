using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tablet : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _gangTeamUI;
    [SerializeField] TextMeshProUGUI _musicUI;
    [SerializeField] TextMeshProUGUI _orderUI;

    [SerializeField] Slider _slider;

    public static string InteractedGoonGangName;
    public static string InteractedGoonMusicName;
    public static string InteractedGoonOrder;
    public static float InteractedGoonMoodValue;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("sdfsfds");
        _gangTeamUI.text = InteractedGoonGangName;
        _musicUI.text = InteractedGoonMusicName;
        _orderUI.text = InteractedGoonOrder;
        _slider.value = InteractedGoonMoodValue;
    }
}
