using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Animation : MonoBehaviour
{
    [SerializeField] private Animator buttonController;
    [SerializeField] private Animator wallController;
    public bool isPressed = false;
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPressed) {
            audio.Play();
            buttonController.SetBool("isPressed", true);
            wallController.SetBool("isOpened", true);
            isPressed = true;
        }
    }
}
