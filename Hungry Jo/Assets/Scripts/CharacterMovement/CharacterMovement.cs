using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{
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

        _characterController.Move(new Vector3(-yDirection, 0, xDirection) * 0.1f);

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
