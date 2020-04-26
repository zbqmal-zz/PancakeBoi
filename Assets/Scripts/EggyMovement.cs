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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime*speed;

        float x = Mathf.Cos(timeCounter)*width;
        float y = 0.25f;
        float z = Mathf.Sin(timeCounter)*width;

        transform.position = new Vector3(x, y, z);
        transform.right = new Vector3(x, 0, z);
    }
}
