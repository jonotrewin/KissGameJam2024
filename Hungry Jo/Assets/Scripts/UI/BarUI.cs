using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BarUI : MonoBehaviour
{
    [SerializeField]List<TextMeshProUGUI> keyTexts = new List<TextMeshProUGUI>();
    [SerializeField]Bar bar;
    private void OnEnable()
    {
        foreach (var key in keyTexts)
        {
            key.text = string.Empty;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < bar._currentKeysForCocktail.Count/*+1*/; i++)
        {
            keyTexts[i].text = bar._currentKeysForCocktail[i].ToString();

        }
    }
}
