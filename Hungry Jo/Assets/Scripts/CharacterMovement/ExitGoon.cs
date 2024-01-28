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
            float happiness = other.gameObject.GetComponent<Goon_Statistics>().CurrentHappiness - 50;

            _slider.value += happiness;

            Destroy(other.gameObject);
        }
    }
}
