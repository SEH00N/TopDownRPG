using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    [SerializeField] float gravityScale = 1f;
    public const float GravityAccel = -9.81f;

    private Rigidbody rb = null;

    private float rayDistance = 1f;
    private bool isGround = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isGround = CheckGround();
    }

    private void FixedUpdate()
    {
        if(isGround) 
        {
            Vector3 velocity = rb.velocity;
            velocity.y = 0f;
            rb.velocity = velocity;
        }
        else
        {
            Vector3 gravity = GravityAccel * gravityScale * Vector3.up;
            rb.AddForce(gravity, ForceMode.Acceleration);
        }
    }

    private bool CheckGround() => Physics.Raycast(transform.position, Vector3.down, rayDistance, 1 << 6);
}
