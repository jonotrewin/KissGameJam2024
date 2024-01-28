using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grinder : MonoBehaviour
{
    [SerializeField] Slider _slider;

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
        //if (Bar.JuicceLevel > 0)
        //{
        //    return;
        //}

        if (other.gameObject.CompareTag("Goon"))
        {
            if (other.gameObject.GetComponent<Goon_Statistics>().GoonColor == Goon_Statistics.Colour.Police)
            {
                //float happiness = other.gameObject.GetComponent<Goon_Statistics>().CurrentHappiness + 50;

                //_slider.value += 100;

                Destroy(other.gameObject);

                if (Bar.JuiceLevelNumber <= 0)
                {
                    Bar.JuiceLevelNumber = 5;
                }

                return;
            }

            if (Bar.JuiceLevelNumber <= 0)
            {
                Bar.JuiceLevelNumber = 5;
            }

            //float happinessTwo = other.gameObject.GetComponent<Goon_Statistics>().CurrentHappiness - 100;

            _slider.value -= 100;

            Destroy(other.gameObject);
        }

        //if (other.gameObject.CompareTag("Goon"))
        //{
        //    Destroy(other.gameObject);

        //    if (Bar.JuicceLevel <= 0)
        //    {
        //        Bar.JuicceLevel = 5;
        //    }

            
            
        //}
    }

    //private void GrindTheGoon(GameObject goonObject)
    //{
    //    //Incriese meter

    //    Destroy(goonObject);
    //}
}
