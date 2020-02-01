using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public GameObject target;
    public float cameraSpeed = 0.3f;
    public float rotationDelta;
    private Vector3 offset;
    private float radius;

    void Start() {
        offset = this.transform.position - target.transform.position;
        radius = (new Vector3(offset.x, 0, offset.z)).magnitude;
    }

    public void Update() {
        float angle = cameraSpeed*Input.GetAxis("Mouse X");

        
        if (Input.GetKey("q")) {
            angle -= rotationDelta;
        }
        if (Input.GetKey("e")) {
            angle += rotationDelta;
        }

        // float newX = radius*Mathf.Cos(Mathf.Acos(offset.x/radius) + angle);
        // float newZ = radius*Mathf.Cos(Mathf.Acos(offset.z/radius) + angle);

        // float newX = offset.x*Mathf.Cos(angle) - offset.z*Mathf.Sin(angle);
        // float newZ = offset.z*Mathf.Cos(angle) - offset.x*Mathf.Sin(angle);

        // float newX = Mathf.Sin(angle + Mathf.Atan(offset.x/offset.z));
        // float newZ = Mathf.Cos(angle + Mathf.Atan(offset.x/offset.z));

        float newX = Mathf.Sin(angle)*(offset.z) + Mathf.Cos(angle)*(offset.x);
        float newZ = Mathf.Cos(angle)*(offset.z) - Mathf.Sin(angle)*(offset.x);

        offset.x = newX;
        offset.z = newZ;
        // this.transform.position = target.transform.position + offset;
        this.transform.position = target.transform.TransformPoint(offset);
    
        this.transform.LookAt(target.transform.position);
    }

    

    
}
