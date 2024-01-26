using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController _characterController;
    

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");

        _characterController.Move(new Vector3(-yDirection, 0, xDirection) * 0.1f);



    }
}
