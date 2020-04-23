using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Animator _animator;
    GameObject _player;
    AudioSource audio;
    public AudioClip hitSound;
    public AudioClip dizzySound;
    int health = 5;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.mute = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        audio.mute = false;
        // if(collision.gameObject.name == "pancakeBoi Variant")
        // {
            audio.PlayOneShot(hitSound, 0.7f);
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
        audio.PlayOneShot(dizzySound, 0.7f);
        yield return new WaitForSeconds(time);
    
        // Code to execute after the delay
        health = 5;
        _animator.SetBool("IsRestored", true);
        Debug.Log("RESTORED!");
        Debug.Log(health);
    }
}
