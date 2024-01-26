using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{
    float _speed = 15f;

    private CharacterController _characterController;

    [SerializeField] private GameObject _characterVisual;

    private Vector3 _mousePosition;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    
    
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");

        _characterController.Move(new Vector3(-yDirection, 0, xDirection) * Time.deltaTime * _speed);

        LocateMouse();

        RotateVisual();

        //if (Input.GetMouseButtonDown(0))
        //{
        //    transform.position = _mousePosition;
        //}

        
    }

    

    private void RotateVisual()
    {
        _characterVisual.transform.LookAt(_mousePosition, Vector3.up);
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
}
