using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackerPlatform : MonoBehaviour
{
    private float delayFall = 2.0f;
    private float delayReset = 4.0f;
    // Update is called once per frame
    private Rigidbody rb;
    private Animator animator;

    Vector3 originalPos;
    void Start(){
        rb = this.GetComponent(typeof(Rigidbody)) as Rigidbody;
        animator = this.GetComponent<Animator>();
        animator.enabled = false;
        originalPos = this.transform.position;
    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Player"){
            animator.enabled = true;
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall(){
        yield return new WaitForSeconds(delayFall);
        rb.isKinematic = false;
        yield return new WaitForSeconds(delayReset);
        rb.isKinematic = true;
        animator.enabled = false;
        this.transform.position = originalPos;
    }
}
