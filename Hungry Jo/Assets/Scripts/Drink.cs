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
       if(collision.gameObject.TryGetComponent<Goon_StateMachine>(out Goon_StateMachine gsm))
        {
            if(gsm.CurrentState == gsm._readyToOrder)
            {
                if(gsm.GetComponent<Goon_Orders>().TestDrink(_cocktailKeyRecipe))
                {
                    gsm.ChangeStates(gsm._drinking);
                    gsm._statistics.hasDrink = true;
                    gsm.GetComponent<Goon_Statistics>().RaiseHappiness(GameSettingsManager.instance.giveDrinkHappinessIncrease);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
