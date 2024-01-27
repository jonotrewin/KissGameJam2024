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
            )
        {
            SitDown(chair); //waits for throw script to resolve

        }
    }

    private void SitDown(Chair chair)
    {
        Debug.Log("Sitting");
        transform.parent = chair.transform;

        chairSittingOn = chair;
        rb.isKinematic = true;
        isSittingDown = true;
        Invoke("SnapToChair", 0.1f);
    }

    private void SnapToChair()
    {
        this.transform.position = chairSittingOn.transform.position;
        chairSittingOn.occupied = true;
    }

    public void StandUp()
    {

        chairSittingOn.occupied = false;
        transform.parent =null;
        rb.isKinematic = false;
        isSittingDown = false;
        chairSittingOn = null;
       


        
    }


}
