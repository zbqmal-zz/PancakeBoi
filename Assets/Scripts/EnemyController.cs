using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    private Transform originalStart;
    private Transform currentTarget;
    private Transform defaultTarget;
    private bool collidedTarget = false;
    public float speed = 1.5f;
    private Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        originalStart = transform;
        if(Vector3.Distance(transform.position, target1.position) > Vector3.Distance(transform.position, target2.position)){
            defaultTarget = target1;
        }else {
            defaultTarget = target2;
        }
        player = GameObject.FindWithTag("Player").transform;
    }

    void OnCollisionEnter(Collision c){
        collidedTarget = true;
        if(defaultTarget == target1){
            defaultTarget = target2;
        }else{
            defaultTarget = target1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < 5.0f){
            Debug.Log("chose player");
            currentTarget = player;
        }else {
            currentTarget = defaultTarget;
        }
        Follow(currentTarget);
        
    }

    void Follow(Transform target){
        float distance = speed * Time.deltaTime;
        //The OnCollisionEnter is called at the start of the game from the object colliding with the ground. This gives a buffer and fixes that
        if(Vector3.Distance(transform.position, target.position) > 1.0f){
            collidedTarget = false;
        }
        if(!collidedTarget){
            transform.position = Vector3.MoveTowards(transform.position, target.position, distance);
        }
    }

}
