using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon_SitDown : MonoBehaviour
{
    Rigidbody rb;
   

    public bool isSittingDown;

    Chair chairSittingOn;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Chair>(out Chair chair) && !isSittingDown && !chair.occupied 
            && !GetComponent<Throwable>()._isFlying)
        {
            Debug.Log("Sitting");
            transform.parent = chair.transform;
            
            chairSittingOn = chair;
            rb.isKinematic = true;
            isSittingDown = !isSittingDown;
            Invoke("SnapToChair", 0.1f); //waits for throw script to resolve

        }
    }

    private void SnapToChair()
    {
        this.transform.position = chairSittingOn.transform.position;
        chairSittingOn.occupied = true;
    }

    public void PickUpLogic()
    {

        chairSittingOn.occupied = false;
        transform.parent =null;
        rb.isKinematic = false;
        isSittingDown = !isSittingDown;
        chairSittingOn = null;
       


        
    }


}
