using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemyAttack : MonoBehaviour
{
    Animator _animator;
    GameObject _player;
    AudioSource audioSource;
    int health = 5;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.mute = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        audioSource.mute = false;
        // if(collision.gameObject.name == "pancakeBoi Variant")
        // {
            audioSource.Play();
        if(collision.gameObject.CompareTag("Projectile") && health >= 2)
        {
            _animator.Play("GetHit");
            // _animator.SetBool("IsHit", true);
            health--;
            Debug.Log(health);
        }
        else if(collision.gameObject.CompareTag("Projectile") && health == 1)
        {
            _animator.Play("Dizzy");
            Debug.Log("Getting Dizzy....");
            StartCoroutine(ExecuteAfterTime(5.0f));
            _animator.SetBool("IsRestored", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _animator.SetBool("IsNearPlayer", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            _animator.SetBool("IsNearPlayer", false);
        }
    }
    public int getHealth() {return health;}

    IEnumerator ExecuteAfterTime(float time)
    {
        // _animator.Play("Dizzy");
        yield return new WaitForSeconds(time);
    
        // Code to execute after the delay
        health = 5;
        _animator.SetBool("IsRestored", true);
        Debug.Log("RESTORED!");
        Debug.Log(health);
    }
}
