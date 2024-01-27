using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObject : MonoBehaviour
{
    GameObject _interactedObject;

    [SerializeField] private GameObject _characterVisual;

    private Vector3 _mousePosition;

    public bool IsCrarryingSomething;

    [SerializeField] GameObject _interactUI;
    [SerializeField] GameObject _tabletUI;

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

        //CheckForObjectToInteractWith();
        CheckForGoonsToInteractWith();

        if (_tabletUI != null)
        {
            if (IsCrarryingSomething)
            {
                _interactUI.SetActive(false);
                _tabletUI.SetActive(false);
            }
        }

        


        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
        }

        CarryInteractedObject();

        if (Input.GetMouseButtonDown(0))
        {
            if (IsCrarryingSomething)
            {
                
                ThrowObject();
                if(_interactedObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                        rb.isKinematic = false;
                }
               _interactedObject = null;
                EventManager.onThrow?.Invoke(_interactedObject); // calls the on throw in event manager
            }

            
        }
    }

    private void CheckForGoonsToInteractWith()
    {
        //if (IsCrarryingSomething) return;

        Collider[] interactables = Physics.OverlapSphere(this.transform.position + _characterVisual.transform.forward * 1.5f, 1.5f);

        foreach (Collider col in interactables)
        {


            if (col.TryGetComponent<ICarryable>(out ICarryable interactable))
            {
                if (col.gameObject.CompareTag("Goon"))
                {
                    if (_tabletUI != null)
                    {
                        if (!col.gameObject.GetComponent<Throwable>()._isFlying)
                        {
                            SetUITexts(col.gameObject);



                            _tabletUI.SetActive(true);
                            _interactUI.SetActive(true);
                        }

                        

                        //Debug.Log("setsitActive");
                    }
                }

                

                //interactable.Interact(gameObject);

                return;
            }
            else
            {
                if (_tabletUI != null)
                {
                    _tabletUI.SetActive(false);
                    _interactUI.SetActive(false);
                }

                CheckForObjectToInteractWith();
                //_interactUI.SetActive(false);
            }





        }
    }

    private void SetUITexts(GameObject goonGameObject)
    {
        goonGameObject.GetComponent<Goon_Statistics>().SetTabletDate();

        goonGameObject.GetComponent<Goon_Orders>().SetKeyCodesOnUI();
    }

    private void CheckForObjectToInteractWith()
    {
        Collider[] interactables = Physics.OverlapSphere(this.transform.position + _characterVisual.transform.forward * 1.5f, 1.5f);

        foreach (Collider col in interactables)
        {
            

            if (col.TryGetComponent<IInteract>(out IInteract interactable))
            {
                if (_interactUI != null)
                {
                    //if (!col.gameObject.GetComponent<Throwable>()._isFlying)
                    //{
                    //    _interactUI.SetActive(true);
                    //}
                    _interactUI.SetActive(true);
                }
                
                //interactable.Interact(gameObject);

                return;
            }
            else
            {
                if (_interactUI != null)
                {
                    _interactUI.SetActive(false);
                }
                //_interactUI.SetActive(false);
            }

            
            


        }
    }

    private void ThrowObject()
    {
        //_interactedObject.GetComponent<Rigidbody>().isKinematic = false;

        IsCrarryingSomething = false;

        LocateMouse();

        Vector3 middle = CalculateMiddle();

        middle.y = 7;

        _interactedObject.GetComponent<Throwable>().Fly(_interactedObject.transform, _mousePosition, middle);

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
        if (IsCrarryingSomething)
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
                if (col.gameObject.GetComponent<Throwable>().IsMoveable)
                {
                    _interactedObject = col.gameObject;

                    _interactedObject.GetComponent<Rigidbody>().isKinematic = true;

                    IsCrarryingSomething = true;

                    if (_interactedObject.TryGetComponent<Goon_SitDown>(out Goon_SitDown sitDown))
                    {
                        sitDown.StandUp();
                        Debug.Log("Picked");
                    }

                    EventManager.onPickUp?.Invoke(col.gameObject);

                    return;
                }

            }

            if (col.TryGetComponent<IInteract>(out IInteract interactable))
            {

                interactable.Interact(gameObject);

                return;
            }

        }
    }
}
