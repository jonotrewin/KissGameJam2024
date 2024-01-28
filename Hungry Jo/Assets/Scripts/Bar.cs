using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bar : MonoBehaviour, IInteract
{
    public static int JuiceLevelNumber = 5;

    CharacterMovement interactingPlayer;
    public List<KeyCode> _currentKeysForCocktail = new List<KeyCode>();

    [SerializeField] bool _listeningToKeySequence = false;

    [SerializeField] GameObject[] _drinks;

    [SerializeField] OrderManager _orderManager;

    [SerializeField] BarUI barUI;
    private void Awake()
    {
        _orderManager = GameObject.FindObjectOfType<OrderManager>();



    }
    void IInteract.Interact(GameObject player)
    {
        if (JuiceLevelNumber <= 0) return;

        if (!_listeningToKeySequence) Invoke("SwitchToTrue", 0.1f);

        interactingPlayer = player.GetComponent<CharacterMovement>();

        interactingPlayer.canMove = false;

    }

    private void SwitchToTrue()
    {
        _listeningToKeySequence = true;
    }

    void Update()
    {
        if (_listeningToKeySequence)
        {
            ListenToKeys();
            barUI.gameObject.SetActive(true);
        }
        AssignSounds();
    }

    void AssignSounds()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AudioManager.instance.PlayOnce("Button01");
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            AudioManager.instance.PlayOnce("Button02");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            AudioManager.instance.PlayOnce("Button03");
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            AudioManager.instance.PlayOnce("Button04");
        }
    }
    void ListenToKeys()
    {
        foreach (KeyCode key in _orderManager.keyCodesForOrders)
        {
            if (Input.GetKeyDown(key))
            {
                //AudioManager.instance.PlayOnce(OrderManager.);
                _currentKeysForCocktail.Add(key);
            }
        }
        if (Input.GetKeyDown(KeyCode.E) || _currentKeysForCocktail.Count >= 4)
        {
            interactingPlayer.GetComponent<CharacterMovement>().canMove = true;
            _listeningToKeySequence = false;

            if (_currentKeysForCocktail.Count < 1)
            {
                return;
            }
            CreateCocktail();
            StartCoroutine(CloseBarUI());

        }
    }

    private IEnumerator CloseBarUI()
    {
        yield return new WaitForSeconds(2);
        _currentKeysForCocktail.Clear();
        barUI.gameObject.SetActive(false);
    }

    private void CreateCocktail()
    {
        foreach (KeyCode key in _currentKeysForCocktail)
        {
            Debug.Log(key);
        }

        GameObject cocktail = Instantiate(_drinks[Random.Range(0, _drinks.Length)]);

        AudioManager.instance.PlayOnce("CorkPop");


        JuiceLevelNumber--;

        for (int i = 0; i < _currentKeysForCocktail.Count; i++)
        {
            cocktail.GetComponent<Drink>()._cocktailKeyRecipe.Add(_currentKeysForCocktail[i]);
        }
    }


}
