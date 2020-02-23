using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpHeight;
    public float moveSpeed;
    public float rotationDelta;
    //public Text resultText;
    //public RawImage img_1, img_2, img_3;

    private float rotationSpeed = 0.3f; 
    public bool isGrounded = true;
    //private int itemCount;
    private bool isAlive = true;

    void Start() {
        rb = this.GetComponent(typeof(Rigidbody)) as Rigidbody;
        //resultText.text = "";
        //itemCount = 0;
        isAlive = true;

        // Not render item_images
        // img_1.enabled = false;
        // img_2.enabled = false;
        // img_3.enabled = false;
    }

    void Update()
    {
        if (isAlive) {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            float rotation = Input.GetAxis("Mouse X")*rotationSpeed*180/Mathf.PI;

            if (Input.GetKey("q")) {
                rotation -= rotationDelta;
            }
            if (Input.GetKey("e")) {
                rotation += rotationDelta;
            }

            this.transform.Rotate(0,rotation,0);

            h = h * Mathf.Sqrt(1f - 0.5f * v * v);
            v = v * Mathf.Sqrt(1f - 0.5f * h * h);
            rb.MovePosition(this.transform.TransformPoint(moveSpeed*h*Time.deltaTime, 0, moveSpeed*v*Time.deltaTime));

            if (rb != null && Input.GetButtonDown("Jump") && isGrounded) {
                isGrounded = false;
                rb.velocity += new Vector3(0,jumpHeight,0);
            }
        }
    }

    void OnCollisionStay() {
        isGrounded = true;
    }

    void OnCollisionExit() {
        isGrounded = false;
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     // Trigger item_1
    //     if (other.gameObject.CompareTag("Item_1"))
    //     {
    //         // Item_image
    //         img_1.enabled = true;

    //         // Item object
    //         other.gameObject.SetActive(false);
            
    //         itemCount++;
    //         setCountText();
    //     }

    //     // Trigger item_2
    //     if (other.gameObject.CompareTag("Item_2"))
    //     {
    //         // Item_image
    //         img_2.enabled = true;

    //         // Item object
    //         other.gameObject.SetActive(false);
            
    //         itemCount++;
    //         setCountText();
    //     }

    //     // Trigger item_3
    //     if (other.gameObject.CompareTag("Item_3"))
    //     {
    //         // Item_image
    //         img_3.enabled = true;

    //         // Item object
    //         other.gameObject.SetActive(false);
            
    //         itemCount++;
    //         setCountText();
    //     }

    //     // Trigger Enemy
    //     if (other.gameObject.CompareTag("Enemy")) {
    //         isAlive = false;
    //         resultText.text = "YOU LOSE!";
    //     }
    // }

    // void setCountText()
    // {
    //     // countText.text = "Count: " + itemCount.ToString();
    //     if (itemCount >= 3)
    //     {
    //         resultText.text = "You Win!";
    //     }
    // }

}
