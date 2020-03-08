using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public GameObject target;
    public float cameraSpeedH = 0.3f;
    public float cameraSpeedV = 0.3f;
    public float cameraLowest = 0f;
    public float cameraHighest = 1f;
    public float rotationDelta;
    public float heightOffset;
    private Vector3 offset;
    private float radius;

    void Start() {
        offset = this.transform.position - target.transform.position + Vector3.up*heightOffset;
        // radius = (new Vector3(offset.x, 0f, offset.z)).magnitude;
        radius = offset.magnitude;
    }

    public void Update() {
        float angleY = -cameraSpeedH*Input.GetAxis("Mouse X");
        float angleX = cameraSpeedV*Input.GetAxis("Mouse Y");
        // angleY = 0f;
        // angleX = 0.5f*Time.deltaTime;

        float oldX = Mathf.Acos(offset.y/radius);
        float oldY = Mathf.Atan2(offset.x, -offset.z);
        float newX =Mathf.Clamp(oldX+angleX, (90-cameraHighest)*Mathf.Deg2Rad, (90-cameraLowest)*Mathf.Deg2Rad);
        
        offset.x = radius*Mathf.Sin(newX)*Mathf.Sin(oldY+angleY);
        offset.y = radius*Mathf.Cos(newX);
        offset.z = -radius*Mathf.Sin(newX)*Mathf.Cos(oldY+angleY);


        // float newX = radius*Mathf.Cos(Mathf.Acos(offset.x/radius) + angle);
        // float newZ = radius*Mathf.Cos(Mathf.Acos(offset.z/radius) + angle);

        // float newX = offset.x*Mathf.Cos(angle) - offset.z*Mathf.Sin(angle);
        // float newZ = offset.z*Mathf.Cos(angle) - offset.x*Mathf.Sin(angle);

        // float newX = Mathf.Sin(angle + Mathf.Atan(offset.x/offset.z));
        // float newZ = Mathf.Cos(angle + Mathf.Atan(offset.x/offset.z));

        // float newX = Mathf.Sin(angleY)*(offset.z) + Mathf.Cos(angleY)*(offset.x);
        // float newZ = Mathf.Cos(angleY)*(offset.z) - Mathf.Sin(angleY)*(offset.x);

        // offset.x = newX;
        // offset.z = newZ;
        this.transform.position = target.transform.position + heightOffset*Vector3.up + offset;
        // this.transform.position = target.transform.TransformPoint(offset);
    
        this.transform.LookAt(target.transform.position + heightOffset*Vector3.up);
    }

    

    
}
