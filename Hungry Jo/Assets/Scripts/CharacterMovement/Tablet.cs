using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tablet : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _gangTeamUI;
    [SerializeField] TextMeshProUGUI _musicUI;
    [SerializeField] TextMeshProUGUI _orderUI;

    public static string InteractedGoonGangName;
    public static string InteractedGoonMusicName;
    public static string InteractedGoonOrder;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        _gangTeamUI.text = InteractedGoonGangName;
        _musicUI.text = InteractedGoonMusicName;
        _orderUI.text = InteractedGoonOrder;
    }
}
