using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemyAttack : MonoBehaviour
{
    Animator _animator;
    GameObject _player;
    AudioSource audioSource;

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
        if(collision.gameObject.name == "pancakeBoi Variant")
        {
            audioSource.Play();
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
}
