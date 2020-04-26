using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggyTerritory : MonoBehaviour
{
    public GameObject enemy;
    Patrol navDestination;
    private GameObject _player;
    public bool inTerritory;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        navDestination = enemy.GetComponent<Patrol>();
        inTerritory = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Eggy Territory's isTriggered: " + inTerritory);
        if(inTerritory)
        {
            // Debug.Log("We in dere");
            // navDestination.changeDestination(_player.transform.position);
            navDestination.isTriggered = true;
        } else 
        {
            // navDestination.ResetDestination();
            navDestination.isTriggered = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            inTerritory = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            inTerritory = false;
        }
    }

    public Vector3 getTargetPos() { return _player.transform.position; }
}
