using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrderManager : MonoBehaviour
{
    public KeyCode[] keyCodesForOrders = new KeyCode[4];
    // Start is called before the first frame update

 

    public List<KeyCode> GetOrderSequence()
    {
        List<KeyCode> sequence = new List<KeyCode>();

        //if(keyCodesForOrders.Length < 4)
        //{
        //    Debug.Log("Not enough Keycodes");
        //    return null;
        //}

        for(int i = 0; i<4; i++)
        {
            sequence.Add(keyCodesForOrders[Random.Range(0, keyCodesForOrders.Length)]);
        }

        return sequence;

    }

 

}
