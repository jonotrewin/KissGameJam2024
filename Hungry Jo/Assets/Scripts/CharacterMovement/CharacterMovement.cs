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

    [SerializeField] LayerMask _floorLayer;

    [SerializeField] GameObject _floorAimingCircle;

    public bool canMove = true;
    bool _isMoving;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        AudioManager.instance.Play("Hovering");
    }

    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");

       if(canMove) _characterController.Move(new Vector3(-yDirection, 0, xDirection) * Time.deltaTime * _speed);

        LocateMouse();

        RotateVisual();

        MoveAimCircle();

        if (xDirection > 0) _isMoving = true;
        else _isMoving = false;
    }



    private void MoveAimCircle()
    {
        if (GetComponent<CarryObject>().IsCrarryingSomething)
        {
            _floorAimingCircle.transform.position = new Vector3(_mousePosition.x, 0.1f, _mousePosition.z);
        }
        else
        {
            _floorAimingCircle.transform.position = new Vector3(_mousePosition.x, -1, _mousePosition.z);
        }

    }


    private void RotateVisual()
    {
        _characterVisual.transform.LookAt(_mousePosition, Vector3.up);
    }

    private void LocateMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _floorLayer))
        {
            _mousePosition = new Vector3(hit.point.x, 1, hit.point.z);

            //Debug.Log(_mousePosition.ToString());
        }
    }
}
