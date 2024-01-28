using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grinder : MonoBehaviour
{


    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Goon"))
    //    {
    //        collision.gameObject.SetActive(false);
    //        //GrindTheGoon(collision.gameObject);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goon"))
        {
            Destroy(other.gameObject);

            if (Bar.JuiceLevel <= 0)
            {
                Bar.JuiceLevel = 5;
            }

            
            //other.gameObject.SetActive(false);
        }
    }

    //private void GrindTheGoon(GameObject goonObject)
    //{
    //    //Incriese meter

    //    Destroy(goonObject);
    //}
}
