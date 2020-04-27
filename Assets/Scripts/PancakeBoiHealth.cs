using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PancakeBoiHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject HUD;
    public int health = 3;
    public float invulnPeriod = 2f;

    private float invulnTime = 0f;
    private float hitTime = 0f;
    private float blinkTime = 0f;
    private float nextPollTime = 0f;
    private Animator animator;
    private SkinnedMeshRenderer mesh;
    public Vector3 lastSafePosition;

    void Start() {
        lastSafePosition = this.transform.position;
        animator = this.GetComponent<Animator>();
        mesh = this.transform.GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>();
    }


    void Update() {
        if (Time.time > hitTime) {
            animator.SetBool("Hit", false);
            mesh.enabled = true;
        }
        
        if (Time.time < invulnTime && Time.time > blinkTime) {
            mesh.enabled = !mesh.enabled;
            blinkTime = Time.time + 0.2f;
        }

        if (Time.time > invulnTime) {
            mesh.enabled = true;
        }

        if (this.GetComponent<PancakBoiControl>().isGrounded && Time.time > nextPollTime) {
            RaycastHit[] hits = Physics.RaycastAll(this.transform.position, Vector3.down, 10f);
            foreach (RaycastHit raycast in hits) {
                if (!raycast.collider.gameObject.CompareTag("FallingPlatform") && !raycast.collider.gameObject.CompareTag("MovingPlatform")) {
                    lastSafePosition = this.transform.position;
                    break;
                }
            }
            nextPollTime = Time.time + 3f;
        }

        if (this.transform.position.y < -10 && Time.time > invulnTime) {
            if (health > 1) {
                invulnTime = Time.time + invulnPeriod;
                HUD.transform.GetChild(--health).gameObject.SetActive(false);
                this.gameObject.GetComponent<PancakBoiControl>().pos = lastSafePosition;
                this.gameObject.GetComponent<PancakBoiControl>().resetPos = true;
            } else {
                SceneManager.LoadScene(0);
            }

        }
    }

    void OnCollisionStay(Collision c) {
        if (c.gameObject.CompareTag("Enemy") && Time.time > invulnTime && health > 1) {
            invulnTime = Time.time + invulnPeriod;
            HUD.transform.GetChild(--health).gameObject.SetActive(false);
            animator.SetBool("Hit", true);
            hitTime = Time.time + 0.2f;
        }
        else if (c.gameObject.CompareTag("Enemy") && Time.time > invulnTime && health  <= 1) {
            SceneManager.LoadScene(0);
        }
    }




}
