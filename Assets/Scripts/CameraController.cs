using UnityEngine;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{
    
    public GameObject target;
    public float cameraSpeedH = 0.07f;
    public float cameraSpeedV = 0.1f;
    public float cameraLowest = 0f;
    public float cameraHighest = 1f;
    public float heightOffset;
    public float speedMultH = 1f;
    public float speedMultV = 1f;
    private Vector3 offset;
    private float radius;

    void Start() {
        offset = this.transform.position - target.transform.position + Vector3.up*heightOffset;
        // radius = (new Vector3(offset.x, 0f, offset.z)).magnitude;
        radius = offset.magnitude;
    }

    public void Update() {
        float angleY = -cameraSpeedH*Input.GetAxis("Mouse X")*speedMultH;
        float angleX = cameraSpeedV*Input.GetAxis("Mouse Y")*speedMultV;

        float oldX = Mathf.Acos(offset.y/radius);
        float oldY = Mathf.Atan2(offset.x, -offset.z);
        float newX =Mathf.Clamp(oldX+angleX, (90-cameraHighest)*Mathf.Deg2Rad, (90-cameraLowest)*Mathf.Deg2Rad);
        
        offset.x = radius*Mathf.Sin(newX)*Mathf.Sin(oldY+angleY);
        offset.y = radius*Mathf.Cos(newX);
        offset.z = -radius*Mathf.Sin(newX)*Mathf.Cos(oldY+angleY);

        this.transform.position = target.transform.position + heightOffset*Vector3.up + offset;
        // this.transform.position = target.transform.TransformPoint(offset);
    
        this.transform.LookAt(target.transform.position + heightOffset*Vector3.up);



        RaycastHit[] rays = Physics.RaycastAll(this.transform.position, target.transform.position - transform.position, radius - 0.5f);


    }
    void OnTriggerEnter(Collider collider) {
        if (!collider.gameObject.CompareTag("Player") && !collider.gameObject.CompareTag("Enemy") && !collider.gameObject.CompareTag("FallingPlatform")) {
            Renderer[] ren = collider.gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in ren) {
                if(!r.gameObject.CompareTag("Enemy")) {
                    r.enabled = false;
                }
            }
        }
    }

    void OnTriggerExit(Collider collider) {
        if (!collider.gameObject.CompareTag("Player") && !collider.gameObject.CompareTag("Enemy") && !collider.gameObject.CompareTag("FallingPlatform")) {
            Renderer[] ren = collider.gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in ren) {
                r.enabled = true;
            }
        }
    }
    

    
}
