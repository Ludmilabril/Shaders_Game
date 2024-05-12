using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody rb;
    private CapsuleCollider col;
    public float ForceJump = 20;
    public float jumpMagnitude = 10;
    public LayerMask LayerFloor;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (InFloor()))
        {
            rb.AddForce(Vector3.up * jumpMagnitude, ForceMode.Impulse);

        }

    }
    private bool InFloor()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, LayerFloor);
    }
}
