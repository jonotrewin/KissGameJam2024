using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObject : MonoBehaviour
{
    GameObject _interactedObject;

    bool _isCrarryingSomething;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
        }

        CarryInteractedObject();
    }

    private void CarryInteractedObject()
    {
        if (_isCrarryingSomething)
        {
            _interactedObject.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        }
    }

    private void InteractWithObject()
    {
        Collider[] interactables = Physics.OverlapSphere(this.transform.position + this.transform.forward * 1.5f, 1.5f);

        foreach (Collider col in interactables)
        {
            if (col.TryGetComponent<IInteract>(out IInteract interactable))
            {
                interactable.Interact(this.gameObject);

                _interactedObject = col.gameObject;

                _isCrarryingSomething = true;

                return;
            }

        }
    }
}
