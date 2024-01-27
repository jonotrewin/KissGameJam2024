using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;

public class Grinder : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goon"))
        {
            GrindTheGoon(other.gameObject);

            //Destroy(other.gameObject);
        }

        
    }

    private void GrindTheGoon(GameObject goonObject)
    {
        //Incriese meter

        goonObject.SetActive(false);
    }
}
