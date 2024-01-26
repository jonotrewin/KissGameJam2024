using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGoon : MonoBehaviour, IInteract
{
    void IInteract.Interact(GameObject gameObject)
    {
        Debug.Log("Picked up Goon");
    }
}
