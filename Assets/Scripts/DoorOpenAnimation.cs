using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenAnimation : MonoBehaviour
{
    [SerializeField] private Animator doorController;
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter(Collider c)
    {
		if (c.CompareTag("Player")) {
            doorController.SetBool("isOpen", true);
            doorController.SetBool("isClose", false);
            audio.Play();
        }
    }

    private void OnTriggerExit(Collider c)
    {
        if (c.CompareTag("Player")) {
            doorController.SetBool("isOpen", false);
            doorController.SetBool("isClose", true);
            audio.Play();
        }
    }
}
