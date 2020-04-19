using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerritory : MonoBehaviour
{
    public GameObject enemy;
    SlimeEnemyMovement slimeEnemy;
    private GameObject _player;
    public bool inTerritory;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        slimeEnemy = enemy.GetComponent<SlimeEnemyMovement>();
        inTerritory = false;
    }

    void Update()
    {
        if(inTerritory)
        {
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
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            // slimeEnemy.ResetDestination();
            inTerritory = false;
        }
    }
}
