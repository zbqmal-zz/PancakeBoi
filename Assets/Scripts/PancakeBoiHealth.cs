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
    private float nextPollTime = 0f;
    public Vector3 lastSafePosition;

    void Start() {
        lastSafePosition = this.transform.position;
    }

    void Update() {
        if (this.GetComponent<PancakBoiControl>().isGrounded && Time.time > nextPollTime) {
            lastSafePosition = this.transform.position;
            nextPollTime = Time.time + 3f;
        }
        // if (Input.GetKeyDown("k")) {
        //     GameObject pcb = Instantiate(this.gameObject, lastSafePosition, Quaternion.identity);
        //     GameObject camera = this.GetComponent<PancakBoiControl>().cam;
        //     pcb.GetComponent<PancakBoiControl>().cam = this.GetComponent<PancakBoiControl>().cam;
        //     camera.GetComponent<CameraController>().target = pcb;
        //     pcb.GetComponent<CollectableLogic>().collectableCount = this.GetComponent<CollectableLogic>().collectableCount;
        //     Destroy(this.gameObject);
        // }

        if (this.transform.position.y < -10 && Time.time > invulnTime) {
            if (health > 1) {
                invulnTime = Time.time + invulnPeriod;
                HUD.transform.GetChild(--health).gameObject.SetActive(false);
                this.gameObject.GetComponent<PancakBoiControl>().pos = lastSafePosition;
                this.gameObject.GetComponent<PancakBoiControl>().resetPos = true;
                // GameObject pcb = Instantiate(this.gameObject, lastSafePosition, Quaternion.identity);
                // GameObject camera = this.GetComponent<PancakBoiControl>().cam;
                // pcb.GetComponent<PancakBoiControl>().cam = this.GetComponent<PancakBoiControl>().cam;
                // camera.GetComponent<CameraController>().target = pcb;
                // pcb.GetComponent<PancakeBoiHealth>().health = health;
                // pcb.GetComponent<PancakeBoiHealth>().HUD = HUD;
                // pcb.GetComponent<CollectableLogic>().collectableCount = this.GetComponent<CollectableLogic>().collectableCount;
                // Destroy(this.gameObject);
            } else {
                SceneManager.LoadScene(0);
            }

        }
    }

    void OnCollisionStay(Collision c) {
        if (c.gameObject.CompareTag("Enemy") && Time.time > invulnTime && health > 1) {
            invulnTime = Time.time + invulnPeriod;
            HUD.transform.GetChild(--health).gameObject.SetActive(false);
        }
        else if (c.gameObject.CompareTag("Enemy") && Time.time > invulnTime && health  <= 1) {
            SceneManager.LoadScene(0);
        }
    }




}
