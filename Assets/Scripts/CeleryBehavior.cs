using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeleryBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audio;
    private Animator animator;
    public Transform player;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        if(player == null){
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnCollisionEnter(Collision collision) {
        Debug.Log("collding");
        if (collision.gameObject.CompareTag("Player")) {
            audio.Play();
            animator.SetTrigger("Shake");
        }
    }
}
