using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon_Orders : MonoBehaviour
{
    [SerializeField] Drink testDrink;
    [SerializeField] OrderManager orderManager;

    public List<KeyCode> orderSequence = new List<KeyCode>();

    public void SetKeyCodesOnUI()
    {
        // Convert the list of KeyCodes to a string
        string keyCodeString = KeyCodeListToString(orderSequence);

        Tablet.InteractedGoonOrder = keyCodeString;

    }

    private string KeyCodeListToString(List<KeyCode> orderSequence)
    {
        // Use StringBuilder for efficient string concatenation
        System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

        // Iterate through the list of KeyCodes
        foreach (KeyCode keyCode in orderSequence)
        {
            // Append the string representation of each KeyCode to the StringBuilder
            stringBuilder.Append(keyCode.ToString());
            stringBuilder.Append(", "); // Add a separator if needed
        }

        // Remove the trailing separator if it exists
        if (stringBuilder.Length > 0)
        {
            stringBuilder.Length -= 2; // Remove the last ", "
        }

        // Convert StringBuilder to string
        return stringBuilder.ToString();
    }

    private void Awake()
    {
        orderManager = GameObject.FindAnyObjectByType<OrderManager>();
    }
    private void OnEnable()
    {
     
        
        orderSequence = orderManager.GetOrderSequence();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            TestDrink(testDrink._cocktailKeyRecipe);
        }
    }

    public bool TestDrink(List<KeyCode> drinkOrderSequence)
    {
        if(drinkOrderSequence.Count != orderSequence.Count)
        {
            Debug.Log("No Match");
            return false;
        }
        for(int i = 0; i < drinkOrderSequence.Count; i++)
        {
            if (drinkOrderSequence[i] != orderSequence[i])
            {
                Debug.Log("No Match!");
                return false;
            }

            
        }
        Debug.Log("Perfect Match");
        return true;
    }
}
