using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakBoiControl : MonoBehaviour
{
    private CharacterController cc; 
    private Animator anim;
    public GameObject cam;

    public float jumpHeight;
    public float midAirVelocity;
    public float jumpFloatness;
    public float fallSpeedMultiplier;

    private float oldRot = 0f;
    public bool isGrounded = true;
    private bool midJump = false;
    private bool falling  = false;
    private float safetyTime = 0f;
    private bool safetyKeep = false;
    public Vector3 vel = Vector3.zero;
    public Vector3 pos = Vector3.zero;
    public bool resetPos = false;


    void Start()
    {
        cc = this.GetComponent(typeof(CharacterController)) as CharacterController;
        anim = this.GetComponent(typeof(Animator)) as Animator;
    }

    // Update is called once per frame

    void FixedUpdate() {
    }

    void Update()
    {   
        anim.SetBool("Throw", false);
        anim.SetBool("Running", false);
        // Vector3 raycastOrigin = this.transform.TransformPoint
        isGrounded = Physics.SphereCast(new Ray(this.transform.TransformPoint(cc.center), Vector3.down), 0.38f, 0.53f);
        bool preGrounded = Physics.SphereCast(new Ray(this.transform.TransformPoint(cc.center), Vector3.down), 0.38f, 1.5f);

        Vector2 facing = Vector2.zero;
        float rot = cam.transform.rotation.eulerAngles.y;
        
        facing.x = Input.GetAxis("Horizontal");
        facing.y = Input.GetAxis("Vertical");

        if (facing.x != 0f || facing.y != 0f) {
            anim.SetBool("Running", true);
            oldRot = Mathf.Rad2Deg*Mathf.Atan2(facing.x, facing.y);
        }
        rot += oldRot;

        if (!isGrounded) {
            if (midJump && !falling) {
                vel.y += Physics.gravity.y*Time.deltaTime* 1/jumpFloatness; 
            } 
            vel.y += Physics.gravity.y*Time.deltaTime*fallSpeedMultiplier;
            anim.SetBool("isGrounded", false);
        } else if (vel.y <= 0f) {
            vel.y = 0;
            anim.SetBool("isGrounded", true);
            anim.SetBool("falling", false);
            anim.SetBool("midJump", false);
            falling = false;
            midJump = false;
        }
        if (preGrounded && vel.y <= 0f) {
            anim.SetBool("isGrounded", true);
            anim.SetBool("falling", false);
            falling = false;
        } else {
            falling = true;
            anim.SetBool("falling", true);
            anim.SetBool("isGrounded", false);
        }
        if (midJump && !falling) {
            anim.SetBool("isGrounded", false);
        }

        // if (y_vel < 0f && !preGrounded) {
        //     falling = true;
        //     anim.SetBool("falling", true);
        // }

        if (Input.GetButton("Jump") && isGrounded && !midJump) {
            vel.y += jumpHeight;
            midJump = true;
            anim.SetBool("midJump", true);
        }

        if ((falling || midJump) && (facing.x != 0f || facing.y != 0f)) {
            Vector3 forward = this.transform.forward;
            forward *= midAirVelocity;
            vel.x = forward.x;
            vel.z = forward.z;
        } else {
            vel.x = 0f;
            vel.z = 0f;
        }

        anim.SetFloat("fallSpeed", vel.y);

        if (Input.GetButtonDown("Fire1")) {
            anim.SetBool("Throw", true);
        }
        


        this.transform.rotation = Quaternion.Euler(0f, rot, 0f);
    }

    void LateUpdate() {
        if (resetPos) {
            this.transform.position = pos;
            vel = Vector3.zero;
            if (!safetyKeep) {
                safetyTime = Time.time + 0.2f;
                safetyKeep = true;
            } else if (Time.time > safetyTime) {
                resetPos = false;
                safetyKeep = false;
                pos = Vector3.zero;
            }
        } else {
            cc.Move(new Vector3(vel.x*Time.deltaTime, (vel.y-cc.velocity.y)*Time.deltaTime, vel.z*Time.deltaTime));
        }

        // if (falling || midJump)
        //     cc.Move(new Vector3(vel.x*Time.deltaTime, (vel.y-cc.velocity.y)*Time.deltaTime, vel.z*Time.deltaTime));
        // else
        //     cc.Move(new Vector3(0f, (vel.y-cc.velocity.y)*Time.deltaTime, 0f));
    }

}
