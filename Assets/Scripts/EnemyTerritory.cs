using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerritory : MonoBehaviour
{
    public GameObject enemy;
    EnemyMovement navDestination;
    private GameObject _player;
    public bool inTerritory;
    Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        navDestination = enemy.GetComponent<EnemyMovement>();
        inTerritory = false;
        _animator = enemy.GetComponent<Animator>();
    }

    void Update()
    {
        if(inTerritory)
        {
            // Debug.Log("We in dere");
            navDestination.changeDestination(_player.transform.position);
        } else 
        {
            navDestination.ResetDestination();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            // navDestination.destination = _player.transform.position;
            inTerritory = true;
            _animator.SetBool("IsInTerritory", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            // navDestination.ResetDestination();
            inTerritory = false;
            _animator.SetBool("IsInTerritory", false);
        }
    }
}
