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
        if(collision.gameObject.CompareTag("Projectile") && health > 2)
        {
            _animator.Play("GetHit");
            // _animator.SetBool("IsHit", true);
            health--;
            Debug.Log(health);
        }
        else if(collision.gameObject.CompareTag("Projectile") && health == 2)
        {
            _animator.Play("Dizzy");
            // _animator.SetBool("IsDamaged", true);
            health--;
            Debug.Log(health);
        }
        else if(collision.gameObject.CompareTag("Projectile") && health <= 1)
        {
            _animator.Play("Die");
            // _animator.SetBool("IsDead", true);
            Destroy(this.gameObject, 5.0f);
        }
        // }

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
}
