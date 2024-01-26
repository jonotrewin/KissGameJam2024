using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goons_Orders : MonoBehaviour
{


    public List<KeyCode> orderSequence = new List<KeyCode>();

    private void OnEnable()
    {
        orderSequence = OrderManager.singleton.GetOrderSequence();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
