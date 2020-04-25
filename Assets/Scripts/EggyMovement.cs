using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EggyMovement : MonoBehaviour
{
    private NavMeshAgent _nav;
    float timeCounter = 0.0f;

    public float speed;
    public float width;

    public enum AIState
    {
        CircleEgg,
        PursuePlayer
    };

    // Start is called before the first frame update
    void Start()
    {
        // speed = 2;
        // width = 3;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime*speed;

        float x = Mathf.Cos(timeCounter)*width;
        float y = 0.25f;
        float z = Mathf.Sin(timeCounter)*width;

        transform.position = new Vector3(x, y,z);
    }
}
