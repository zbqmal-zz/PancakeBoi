using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerritory : MonoBehaviour
{
    public GameObject enemy;
    public GameObject slime;
    SlimeEnemyMovement slimeEnemy;
    private GameObject _player;
    public bool inTerritory;
    Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        slime = GameObject.FindGameObjectWithTag("Slime Enemy");
        slimeEnemy = enemy.GetComponent<SlimeEnemyMovement>();
        inTerritory = false;
        _animator = slime.GetComponent<Animator>();
    }

    void Update()
    {
        if(inTerritory)
        {
            // Debug.Log("We in dere");
            slimeEnemy.changeDestination(_player.transform.position);
        } else 
        {
            slimeEnemy.ResetDestination();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            // slimeEnemy.destination = _player.transform.position;
            inTerritory = true;
            _animator.SetBool("IsInTerritory", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            // slimeEnemy.ResetDestination();
            inTerritory = false;
            _animator.SetBool("IsInTerritory", false);
        }
    }
}
