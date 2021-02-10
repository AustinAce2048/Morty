using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float forwardWalkSpeed = 0;
    public float reverseWalkSpeed = 0;
    public float strafeSpeed = 0;
    public float sprintMultiplier = 0f;
    public float crouchDivider = 0f;
    public float decelerationMultiplier = 0f;
    public float topSpeed = 0f;

    private Rigidbody rb;
    private bool isAcceleratingForward = false;
    private bool isAcceleratingReverse = false;
    private bool isAcceleratingLeft = false;
    private bool isAcceleratingRight = false;

    void Start () {
        rb = GetComponent<Rigidbody> ();
    }

    void Update () {
        //Movement handeling
        //Forward
        if (Input.GetKey (KeyCode.W)) {
            rb.AddForce (transform.forward * forwardWalkSpeed, ForceMode.Acceleration);
            isAcceleratingForward = true;
        } else {
            isAcceleratingForward = false;
        }
        if (Input.GetKey (KeyCode.S)) {
            rb.AddForce (-transform.forward * reverseWalkSpeed, ForceMode.Acceleration);
            isAcceleratingReverse = true;
        } else {
            isAcceleratingReverse = false;
        }
        if (Input.GetKey (KeyCode.A)) {
            rb.AddForce (-transform.right * strafeSpeed, ForceMode.Acceleration);
            isAcceleratingLeft = true;
        } else {
            isAcceleratingLeft = false;
        }
        if (Input.GetKey (KeyCode.D)) {
            rb.AddForce (transform.right * strafeSpeed, ForceMode.Acceleration);
            isAcceleratingRight = true;
        } else {
            isAcceleratingRight = false;
        }

        //Speed cap
        /*if (rb.velocity.magnitude > topSpeed) {
            rb.velocity = rb.velocity.normalized * topSpeed;
        }*/
        //Natural slowdown
        if (!isAcceleratingForward && !isAcceleratingReverse && !isAcceleratingLeft && !isAcceleratingRight) {
            rb.AddForce (-rb.velocity * decelerationMultiplier, ForceMode.Acceleration);
        }
    }

}