using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float attack1Range = 1f;
    public int attack1Damage = 1;
    public float timeBetweenAttacks;

    public float playerDistance;
    public float rotationDamping;
    public float moveSpeed;
    public static bool isPlayerAlive = true;

    // private bool collidedTarget = false;

    // float maxWalkSpeed = 10.0f;
    // float maxTurnSpeed = 100.0f;

    public int hitCount = 3; //number of hits
    public float hitTime = 2; //time in seconds between each hit
    float curTime = 0; //time in seconds since last hit

    private Animator anim;
    private bool isDistCheck = false;
    private float timeLeft = 3.0f;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        if (anim == null)
            Debug.Log("Animator could not be found");

        Rest();
    }

    // Update is called once per frame
    void Update()
    {
        // Follow(target);
        // CharacterUtil.RotateTowards(PlaterController.Instance.transform, transform);
        if(isPlayerAlive)
        {
            playerDistance = Vector3.Distance(target.position, transform.position);

            if(playerDistance < 5000f) {
                lookAtPlayer();
            }

            if(playerDistance < 4090f)
            {
                if(playerDistance > 1.8f) {
                    chase();
                } else if(playerDistance < 1.8f)
                {
                    if (curTime >= hitTime ) //if the set amount of time has passed
                    {
                        attack ();
                    }
                }
            }
            if (hitCount > 0) //if there are more hits left
            {
                curTime += Time.deltaTime; //add time
            }
        }

        if(playerDistance < 3.0f)
        {
            if(!isDistCheck)
            {
                isDistCheck = true;
            }
            else 
            {
                timeLeft -= Time.deltaTime;
            }

            if(timeLeft <= 0.0f)
            {
                //Attack
                anim.SetBool("shouldAttack", true);
            }
            else
            {
                anim.SetBool("shouldAttack", false);
                isDistCheck = false;
                timeLeft = 3.0f;
            }
        }
    }

    public void AttackEnd()
    {
        // Send Damage to the Player
        // PlayerController.Instance.OnHit(this.gameObject, 35);
        //Play damage animation
        // PlayerController.Instance.DoDeadByDamage("Damage");
    }

    // void OnCollisionEnter(Collision other)
    // {
    //     collidedTarget = true;
    // }

    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation (target.position - transform.position);
        transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);

    }

    void chase()
    {
        transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void attack() 
    {
        RaycastHit hit;
         if (Physics.Raycast (transform.position, transform.forward, out hit))
         {
             if(hit.collider.gameObject.tag == "Player")
             {
                 hit.collider.gameObject.GetComponent<Health>().health -= 5f;
             }
         }
        curTime = 0; //reset the time
        hitCount--; //subtract one from the hit count
    }
    public void MoveToPlayer()
    {
        //rotate to look at player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3 (0, -90, 0), Space.Self);
    
        //move towards player
        if (Vector3.Distance(transform.position, target.position) > attack1Range) 
        {
                transform.Translate(new Vector3 (speed * Time.deltaTime, 0, 0));
        }
    }

    public void Rest()
    {

    }

    void Follow(Transform target){
        float distance = speed * Time.deltaTime;
        
        // anim.Play("Walk", 0, 0);
        transform.position = Vector3.MoveTowards(transform.position, target.position, distance);
    }
 }