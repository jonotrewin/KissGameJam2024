using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour, ICarryable
{
    //public Transform A;
    //public Transform B;
    //public Transform Control;

    public bool IsMoveable = true;

    public CurveThing Curve;

    bool _isFlying;


    float speed = 3f;

    float _sampleTime;

    public void Fly(Transform a, Vector3 b, Vector3 c)
    {
        Instantiate(Curve);

        _sampleTime = 0f;

        Curve.A = a;
        Curve.B.position = b;
        Curve.Control.position = c;

        _isFlying = true;
    }

    //private void Start()
    //{
    //    _sampleTime = 0f;
    //}

    private void Update()
    {
        if (_isFlying)
        {
            _sampleTime += Time.deltaTime * speed;
            transform.position = Curve.Evaluate(_sampleTime);
            transform.forward = Curve.Evaluate(_sampleTime) - transform.position;

            if (_sampleTime >= 1f)
            {
                _isFlying = false;
            }
        }
    }
}
