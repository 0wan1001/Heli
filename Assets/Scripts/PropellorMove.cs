using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellorMove : MonoBehaviour
{
    [SerializeField] private GameObject _propellorPrefab;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _propellorRotateSpeed;
    [SerializeField] private float _propellorAcceleration;
    private float _acceleration;

    private void Update()
    {
        
        _acceleration += _propellorAcceleration * Time.deltaTime;
        PropellorRotate();
    }


    private void PropellorRotate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(Vector3.up, _propellorRotateSpeed * Time.deltaTime * _acceleration);
        }
    }
}
