using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour, ICarryable
{
    // Start is called before the first frame update
    public List<KeyCode> _cocktailKeyRecipe;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HOLA");
    }
}
