using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyPlayerController : MonoBehaviour
{
    [Header("Basic Data")]
    public float moveSpeed = 6.0f;
    public float turnSpeed = 150.0f;
    public float jumpForce = 5.0f;
    bool IsGrounded = true;

    private void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck())
            Jump();

        Movement();
    }

    //ws move forward and backward
    //ad to turn camera
    void Movement()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    void Jump()
    {
        IsGrounded = false;
        GetComponent<Rigidbody>().AddForce(0, jumpForce, 0, ForceMode.Impulse);
    }

    //check whether the player is on the ground or in the air.
    bool GroundCheck()
    {
        return Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y + 0.1f);
    }

}
