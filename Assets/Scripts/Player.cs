using System.Collections;
using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine;

public class Player : NetworkBehaviour
{
    private Vector2 _facingDirection = new Vector2(1f, 0f);
    
    protected void Update()
    {
        if (IsOwner == false)
        {
            return;
        }
        
        Vector2 input = new (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        if (input.magnitude > 0.01f)
        {
            _facingDirection = input.normalized;
            transform.position += new Vector3(input.x, input.y, 0f) * Time.deltaTime;
        }
        
        transform.rotation = Quaternion.LookRotation(Vector3.forward, _facingDirection) * Quaternion.Euler(0f, 0f, 90f);
    }
}
