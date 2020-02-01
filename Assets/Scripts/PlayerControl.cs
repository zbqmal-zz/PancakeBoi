using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpHeight;
    public float moveSpeed;
    public float rotationDelta;

    private float rotationSpeed = 0.3f; 
    private bool isGrounded = true;
    void Start() {
        rb = this.GetComponent(typeof(Rigidbody)) as Rigidbody;
    }
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float rotation = Input.GetAxis("Mouse X")*rotationSpeed*180/Mathf.PI;

        if (Input.GetKey("q")) {
            rotation -= rotationDelta;
        }
        if (Input.GetKey("e")) {
            rotation += rotationDelta;
        }

        this.transform.Rotate(0,rotation,0);

        h = h * Mathf.Sqrt(1f - 0.5f * v * v);
        v = v * Mathf.Sqrt(1f - 0.5f * h * h);
        rb.MovePosition(this.transform.TransformPoint(moveSpeed*h*Time.deltaTime, 0, moveSpeed*v*Time.deltaTime));

        if (rb != null && Input.GetButtonDown("Jump") && isGrounded) {
            isGrounded = false;
            rb.velocity += new Vector3(0,jumpHeight,0);
        }

    }

    void OnCollisionEnter() {
        isGrounded = true;
    }

    void OnCollisionExit() {
        isGrounded = false;
    }

}
