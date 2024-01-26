using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObject : MonoBehaviour
{
    GameObject _interactedObject;

    [SerializeField] private GameObject _characterVisual;

    private Vector3 _mousePosition;

    bool _isCrarryingSomething;

    // Start is called before the first frame update


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(this.transform.position + _characterVisual.transform.forward * 1.5f, 1.5f);
    }
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

        if (Input.GetMouseButtonDown(0))
        {
            if (_isCrarryingSomething)
            {
                ThrowObject();
            }

            
        }
    }

    private void ThrowObject()
    {
        //_interactedObject.GetComponent<Rigidbody>().isKinematic = false;

        _isCrarryingSomething = false;

        LocateMouse();

        Vector3 middle = CalculateMiddle();

        middle.y = 7;

        _interactedObject.GetComponent<FlyGoonFly>().Fly(_interactedObject.transform, _mousePosition, middle);

        //_interactedObject.GetComponent<Rigidbody>().velocity = ;

        //_interactedObject.GetComponent<Rigidbody>().velocity = _characterVisual.transform.forward * 15;


    }

    private Vector3 CalculateMiddle()
    {
        float t = 0.5f; // 0.5 represents the midpoint
        Vector3 midpoint = Vector3.Lerp(_interactedObject.transform.position, _mousePosition, t);

        return midpoint;
    }

    private void LocateMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            _mousePosition = new Vector3(hit.point.x, 1, hit.point.z);

            //Debug.Log(_mousePosition.ToString());
        }
    }

    private void CarryInteractedObject()
    {
        if (_isCrarryingSomething)
        {
            //_interactedObject.GetComponent<Rigidbody>().isKinematic = true;

            _interactedObject.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

            _interactedObject.transform.rotation = _characterVisual.transform.rotation;

            _interactedObject.transform.Rotate(new Vector3(90, 0, 0));
        }
    }

    private void InteractWithObject()
    {
        Collider[] interactables = Physics.OverlapSphere(this.transform.position + _characterVisual.transform.forward * 1.5f, 1.5f);

        foreach (Collider col in interactables)
        {
            if (col.TryGetComponent<ICarryable>(out ICarryable carryable))
            {
                if (col.gameObject.GetComponent<TestGoon>().IsMoveable)
                {
                    _interactedObject = col.gameObject;

                    _isCrarryingSomething = true;



                    return;
                }

            }

            if (col.TryGetComponent<IInteract>(out IInteract interactable))
            {


                interactable.Interact(gameObject);

                _interactedObject = col.gameObject;

                _isCrarryingSomething = true;



                return;
            }

        }
    }
}
