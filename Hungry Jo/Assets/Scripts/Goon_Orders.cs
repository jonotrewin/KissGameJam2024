using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon_Orders : MonoBehaviour
{
    [SerializeField] Drink testDrink;
    [SerializeField] OrderManager orderManager;

    public List<KeyCode> orderSequence = new List<KeyCode>();

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

    public void TestDrink(List<KeyCode> drinkOrderSequence)
    {
        if(drinkOrderSequence.Count != orderSequence.Count)
        {
            Debug.Log("No Match");
        }
        for(int i = 0; i < drinkOrderSequence.Count; i++)
        {
            if (drinkOrderSequence[i] != orderSequence[i])
            {
                Debug.Log("No Match!");
                return;
            }

            
        }
        Debug.Log("Perfect Match");
    }
}
