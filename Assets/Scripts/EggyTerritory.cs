using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggyTerritory : MonoBehaviour
{
    public GameObject enemy;
    EnemyMovement navDestination;
    private GameObject _player;
    public bool inTerritory;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        navDestination = enemy.GetComponent<EnemyMovement>();
        inTerritory = false;
    }

    // Update is called once per frame
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
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            // navDestination.ResetDestination();
            inTerritory = false;
        }
    }
}
