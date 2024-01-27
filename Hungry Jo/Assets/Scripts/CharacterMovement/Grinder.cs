using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grinder : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goon"))
        {
            GrindTheGoon(collision.gameObject);
        }
    }

    private void GrindTheGoon(GameObject goonObject)
    {
        //Incriese meter

        Destroy(goonObject);
    }
}
