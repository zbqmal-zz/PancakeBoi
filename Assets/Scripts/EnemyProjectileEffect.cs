using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyProjectileEffect : MonoBehaviour
{
    private Rigidbody rigidbody;
    private NavMeshAgent navMeshAgent;
    private EnemyMovement aI;
    private Patrol patrol;
    private Collider collider;
    private GameObject butter;
    private GameObject thisButter;
    public float force;
    public float drag;
    private float timer = -1f;
    private bool hit = false;
    private bool restoring = false;
    private Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
        aI = this.gameObject.GetComponent<EnemyMovement>();
        patrol = this.gameObject.GetComponent<Patrol>();
        collider = this.gameObject.GetComponent<Collider>();
        butter = GameObject.Find("butterDebuff");
        originalPos = this.gameObject.transform.position;
    }

    void Update() {
        if (timer >= 0f && timer < Time.time) {
            if (restoring) {
                gameObject.transform.position = originalPos;
            }
            hit = false;
            navMeshAgent.enabled = true;
            if (aI != null)aI.enabled = true;
            if (patrol != null) patrol.enabled = true;
            GameObject.Destroy(thisButter);
            restoring = false;
        }
        if ((this.transform.position.z < -50 ) && !restoring) {
            restoring = true;
            if (aI != null)aI.enabled = false;
            if (patrol != null) patrol.enabled = false;
            restoring = true;
            timer = Time.time + 3f;
        }
    }
    void OnCollisionEnter(Collision c) {
        if (c.gameObject.CompareTag("Projectile")) {
            navMeshAgent.enabled = false;
            if (aI != null)aI.enabled = false;
            if (patrol != null) patrol.enabled = false;
            if (c.rigidbody.velocity.magnitude < 0.5f) {
                Vector3 push = navMeshAgent.desiredVelocity*force;
                push.y = 0f;
                rigidbody.AddForce(push);
            } else {
                rigidbody.AddForce(c.rigidbody.velocity*force);
            }
            if (hit) {
                GameObject.Destroy(thisButter);
            }
            thisButter = Instantiate(butter, this.gameObject.transform);
            thisButter.gameObject.SetActive(true);
            thisButter.GetComponent<MeshRenderer>().enabled = true;
            timer = Time.time+2f;
            hit = true;
        }
    }
}
