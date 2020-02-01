using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    void Start() {
        rb = this.GetComponent(typeof(Rigidbody)) as Rigidbody;
    }
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        this.transform.position += new Vector3(3*h*Time.deltaTime,0,3*v*Time.deltaTime);
        if (rb != null && Input.GetButtonDown("Jump")) {
            rb.velocity += new Vector3(0,7,0);
        }
        
    }
}
