using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterScript : MonoBehaviour
{
    private float timer = -1f;
    // Start is called before the first frame update
    void Update() {
        if ((timer >= 0f && timer < Time.time) || this.gameObject.transform.position.y < -50) {
            GameObject.Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision c) {
        if (c.gameObject.CompareTag("Enemy")) {
            GameObject.Destroy(this.gameObject);
        } else {
            timer = Time.time + 10;
        }
    }
}
