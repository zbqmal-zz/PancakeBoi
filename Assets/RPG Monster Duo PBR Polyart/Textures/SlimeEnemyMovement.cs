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
    

    // Start is called before the first frame update
    void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        initialPos = transform.position;
        initialRotation = transform.rotation;
        destination = initialPos;
    }

    // Update is called once per frame
    void Update()
    {
        _nav.SetDestination(destination);
        // _nav.SetDestination(_player.position);
    }
    public void changeDestination(Vector3 newDestination)
    {
        destination = newDestination;
    }

    public void ResetDestination()
    {
        destination = initialPos;
    }
}
