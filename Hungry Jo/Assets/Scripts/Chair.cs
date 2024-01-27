using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    [SerializeField]Transform sittingPosition;
    [SerializeField] public bool occupied;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders= Physics.OverlapSphere(this.transform.position, 2f);
        
        foreach(Collider col in colliders)
        {
            if (col.TryGetComponent<Goon_SitDown>(out Goon_SitDown goon) && goon.isSittingDown)
            {
                occupied = true;
                return;
            }
            else occupied = false;
        }
           
        

    }
}
