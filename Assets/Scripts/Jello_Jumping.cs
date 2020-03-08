using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jello_Jumping : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private Animator jelloController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            controller.vel.y = 15f;
        }
    }
}
