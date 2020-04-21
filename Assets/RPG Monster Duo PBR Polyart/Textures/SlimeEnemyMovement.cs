using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeEnemyMovement : MonoBehaviour
{
    private NavMeshAgent _nav;
    private Transform _player;

    // storing intial position and limiting movement
    private Vector3 initialPos;
    private Quaternion initialRotation;
    Vector3 destination;
    int health;
    

    // Start is called before the first frame update
    void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        initialPos = transform.position;
        initialRotation = transform.rotation;
        destination = initialPos;

        health = this.GetComponent<SlimeEnemyAttack>().getHealth();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(destination == _player.position);
        _nav.SetDestination(destination);
        health = this.GetComponent<SlimeEnemyAttack>().getHealth();
        // _nav.SetDestination(_player.position);
    }
    public void changeDestination(Vector3 newDestination)
    {
        destination = newDestination;
    }

    public void ResetDestination()
    {
        // Debug.Log("Back to Inital pos.");
        destination = initialPos;
    }
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        if(collision.gameObject.CompareTag("Projectile") && health <= 2)
        {
            _nav.Stop();
            Debug.Log("Stopped nav agent");
        }

    }
}
