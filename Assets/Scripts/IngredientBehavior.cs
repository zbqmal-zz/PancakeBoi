using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private AudioSource audio;
    public Transform player;
    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null){
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else{
            if(Vector3.Distance(transform.position, player.position) < 7.0f){
                animator.SetBool("PlayerClose", true);
            }else{
                animator.SetBool("PlayerClose", false);
            }
        }
    }
    void OnCollisionEnter(Collision collision){
        Debug.Log("colliding");
        if(collision.collider.gameObject.CompareTag("Player")){
            audio.Play();
            StartCoroutine(Deactivate());
        }

    }
    IEnumerator Deactivate(){
        yield return new WaitForSeconds(0.2f);
        this.gameObject.SetActive(false);
    }
}
