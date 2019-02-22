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
    private Animator anim = null;
    bool IsGrounded = true;

    [Header("Teleport Location Data")]
    public Transform teleportPosition;

    private void Start()
    {
        //get animator
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(GroundCheck() && IsGrounded == false)
            anim.SetTrigger("stopJump");

        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck())
            Jump();

        if (Input.GetKeyDown(KeyCode.P))
        {
            gameObject.transform.position = teleportPosition.position;
        }

        Movement();
    }

    //ws move forward and backward
    //ad to turn camera
    void Movement()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        anim.SetFloat("moveSpeed", Mathf.Abs(Input.GetAxis("Vertical")));
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    void Jump()
    {
        IsGrounded = false;
        anim.SetTrigger("jump");
        GetComponent<Rigidbody>().AddForce(0, jumpForce, 0, ForceMode.Impulse);
    }

    //check whether the player is on the ground or in the air.
    bool GroundCheck()
    {
        return Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y + 0.1f);
    }

}
