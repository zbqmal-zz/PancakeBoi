using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Wall : MonoBehaviour
{
    private AudioSource audio;
    [SerializeField] private Animator wallController;
    public bool isOpen = false;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wallController.GetBool("isOpened") && !isOpen) {
            isOpen = true;
            audio.Play();
        }
    }
}
