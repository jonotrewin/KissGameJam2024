using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGoon : MonoBehaviour
{
    [SerializeField] Slider _slider;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goon"))
        {
            if (other.gameObject.GetComponent<Goon_StateMachine>().CurrentState is Goon_State_Leave)
            {
                if (other.gameObject.GetComponent<Goon_Statistics>().GoonColor == Goon_Statistics.Colour.Police)
                {
                    float happiness = other.gameObject.GetComponent<Goon_Statistics>().CurrentHappiness + 50;

                    _slider.value += happiness;

                    Destroy(other.gameObject);

                    return;
                }

                float happinessTwo = other.gameObject.GetComponent<Goon_Statistics>().CurrentHappiness - 50;

                _slider.value += happinessTwo;

                Destroy(other.gameObject);
            }
            else if(other.gameObject.GetComponent<Goon_StateMachine>().CurrentState is Goon_State_Angry)
            {
                if (other.gameObject.GetComponent<Goon_Statistics>().GoonColor == Goon_Statistics.Colour.Police)
                {
                    float happiness = other.gameObject.GetComponent<Goon_Statistics>().CurrentHappiness + 50;

                    _slider.value += happiness;

                    Destroy(other.gameObject);

                    return;
                }

                float happinessTwo = other.gameObject.GetComponent<Goon_Statistics>().CurrentHappiness - 50;

                _slider.value += happinessTwo;

                Destroy(other.gameObject);
            }


        }
    }
}
