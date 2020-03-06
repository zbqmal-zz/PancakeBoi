using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public bool appear;
    void Start()
    {
        appear = true;
        this.gameObject.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
