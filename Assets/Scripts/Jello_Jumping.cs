using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jello_Jumping : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private Animator jelloController;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.mute = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        audioSource.mute = false;
        if(collision.gameObject.name == "pancakeBoi Variant")
        {
            audioSource.Play();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            jelloController.SetBool("isJump", true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) {
            jelloController.SetBool("isJump", false);
            PancakBoiControl controller = other.GetComponent(typeof(PancakBoiControl)) as PancakBoiControl;
            controller.vel.y = 20f;
        }
    }
}
