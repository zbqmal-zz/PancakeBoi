using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class SlimeAI : MonoBehaviour
{
    private Animator anim;
    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    public GameObject[] waypoints;
    public int currWaypoint;

    private VelocityReporter velocity;
    public Transform target;
    private bool wasAtMoving;
    Vector3 futureTarget;

    public enum AIState
    {
        StationaryWaypoints,
        AttackPlayer
    };

    public AIState aiState;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        if (anim == null)
            Debug.Log("Animator could not be found");

        currWaypoint = -1;
        // setNextWaypoint();

        aiState = AIState.StationaryWaypoints;

        velocity = target.GetComponent<VelocityReporter>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (aiState)
        {
            case AIState.StationaryWaypoints:
                // set and go to next waypoint
                if (navMeshAgent.pathPending != true && navMeshAgent.remainingDistance == 0)
                {
                    float m_dist = (target.position - navMeshAgent.transform.position).magnitude;
                    float s_dist = (waypoints[getNextWaypoint()].transform.position - navMeshAgent.transform.position).magnitude;
                    if (s_dist < m_dist || wasAtMoving)
                    {
                        setNextWaypoint();
                        wasAtMoving = false;
                    }
                    else
                    {
                        aiState = AIState.AttackPlayer;
                    }
                }
                break;

            case AIState.AttackPlayer:
                // float dist = (target.transform.position - transform.position).magnitude;
                // float prediction = dist / navMeshAgent.speed;
                // prediction = Mathf.Clamp(prediction, 0, 0.2f);
                // futureTarget = target.transform.position + prediction * velocity.velocity;

                steerToMovingWaypoint();

                if (navMeshAgent.pathPending != true && (navMeshAgent.remainingDistance - navMeshAgent.stoppingDistance) < 0.5f)
                {
                    aiState = AIState.StationaryWaypoints;
                }

                wasAtMoving = true;
                break;
        }

        // anim.SetFloat("vely", navMeshAgent.velocity.magnitude / navMeshAgent.speed);
    }

    private void setNextWaypoint()
    {
        if(currWaypoint >= waypoints.Length - 1)
        {
            currWaypoint = 0;
        } else
        {
            currWaypoint++;
        }
        if (waypoints.Length != 0)
        {
            navMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);
        }
    }

    private int getNextWaypoint()
    {
        if (currWaypoint >= waypoints.Length - 1)
        {
            return 0;
        }
        else
        {
            return currWaypoint + 1;
        }
    }

    private void steerToMovingWaypoint()
    {
        
        navMeshAgent.SetDestination(target.position);
        //navMeshAgent.SetDestination(target.transform.position);
    }
}
