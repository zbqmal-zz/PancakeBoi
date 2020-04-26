using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform[] waypoints;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public bool isTriggered;
    public GameObject bounds;
    private EggyTerritory territory;
    int health;

    public enum AIState
    {
        PatrolIngredient,
        PursuePlayer
    };

    public AIState aiState;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        territory = bounds.GetComponent<EggyTerritory>();
        health = this.GetComponent<EnemyAttack>().getHealth();
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        // agent.autoBraking = false;
        aiState = AIState.PatrolIngredient;
        // GotoNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        health = this.GetComponent<EnemyAttack>().getHealth();
        // isTriggered = this.GetComponent<EggyTerritory>().isTriggered;
        if(health > 1) 
        { 
            agent.isStopped = false;
        }
        // Debug.Log("Patrol's isTriggered: " + isTriggered);
        // Choose the next destination point when the agent gets
        // close to the current one.
        switch(aiState) {
            case(AIState.PatrolIngredient):
                if (isTriggered) {
                    Debug.Log("Inside Territory");
                    aiState = AIState.PursuePlayer; 
                }
                else {
                    if (!agent.pathPending && agent.remainingDistance < 0.5f) { GotoNextPoint(); }
                }
            break;
            case(AIState.PursuePlayer):
                if(!isTriggered) {
                    destPoint--;
                    aiState = AIState.PatrolIngredient;
                } else {
                    Debug.Log("Going Towards Player");
                    Vector3 target = territory.getTargetPos();
                    agent.SetDestination(target);
                }
            break;
        }
        
    }
    void GotoNextPoint() {
        // Returns if no points have been set up
        if (waypoints.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = waypoints[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % waypoints.Length;
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        if(collision.gameObject.CompareTag("Projectile") && health == 1)
        {
            agent.isStopped = true;
            Debug.Log("Stopped nav agent");
        } 

    }

}
