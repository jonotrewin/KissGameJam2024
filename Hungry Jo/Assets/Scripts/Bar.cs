using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bar : MonoBehaviour, IInteract
{
    
    List<KeyCode> _currentKeysForCocktail = new List<KeyCode>();

    [SerializeField]bool _listeningToKeySequence = false;

    [SerializeField]GameObject[] _drinks;

    [SerializeField]OrderManager _orderManager;

    private void Awake()
    {
        _orderManager = GameObject.FindObjectOfType<OrderManager>();
    }
    void IInteract.Interact(GameObject player)
    {
        if(!_listeningToKeySequence)Invoke("SwitchToTrue", 0.1f);
    }

    private void SwitchToTrue()
    {
        _listeningToKeySequence = true;
    }

    void Update()
    {
        if(_listeningToKeySequence)ListenToKeys();
    }

    void ListenToKeys()
    {
        foreach (KeyCode key in _orderManager.keyCodesForOrders)
        {
            if( Input.GetKeyDown(key))
            {
                
                _currentKeysForCocktail.Add(key);
            }
        }
        if(Input.GetKeyDown(KeyCode.E) ||  _currentKeysForCocktail.Count >=4)
        {
            _listeningToKeySequence = false;
            if (_currentKeysForCocktail.Count < 1 )
            {
                return;
            }
            CreateCocktail();
            _currentKeysForCocktail.Clear();
            

        }
    }

    private void CreateCocktail()
    {
        foreach(KeyCode key in _currentKeysForCocktail)
        {
            Debug.Log(key);
        }

        GameObject cocktail = Instantiate(_drinks[Random.Range(0, _drinks.Length)]);

        for (int i = 0; i < _currentKeysForCocktail.Count; i++)
        {
            cocktail.GetComponent<Drink>()._cocktailKeyRecipe.Add(_currentKeysForCocktail[i]);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Goon_StateMachine>(out Goon_StateMachine gsm))
        {
            if(gsm.CurrentState is Goon_State_ReadyToOrder)
            {
                
            }
        }
    }
}
