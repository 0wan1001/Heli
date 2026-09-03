using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    

    private void Update()
    {
        Vector3 movement = GetMovement();
        Move(movement);

    }

    private void Move(Vector3 movement)
    {
        if (movement == Vector3.zero)
        {
            return;
        }
        transform.Translate(movement * _moveSpeed * Time.deltaTime);
        
    }

    private Vector3 GetMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        
        Vector3 movement = new Vector3(x, 0, z);
        return movement.normalized;
    }
}
