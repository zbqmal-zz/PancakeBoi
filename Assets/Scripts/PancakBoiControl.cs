using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakBoiControl : MonoBehaviour
{
    private CharacterController cc; 
    private Animator anim;
    private CapsuleCollider collider;
    public GameObject cam;

    public float jumpHeight;
    public float midAirVelocity;
    public float jumpFloatness;
    public float fallSpeedMultiplier;
    public float speedMultiplier;

    private float oldRot = 0f;
    public bool isGrounded = true;
    private bool midJump = false;
    private bool falling  = false;
    private float safetyTime = 0f;
    private bool safetyKeep = false;
    private bool onPlatform = false;
    private GameObject MovingPlatform;
    private Vector3 oldPlatformPos;

    private GameObject handPosition;
    private Rigidbody butterProjectile;
    private Rigidbody thisProjectile;
    public float projectileForce;
    private RectTransform fillBar;
    private bool recharging = false;
    private float readyTime;
    public float rechargeTime = 5f;
    private Vector2 startAnchorLeft;
    private Vector2 endAnchorLeft;
    private Vector2 startAnchorRight;
    private Vector2 endAnchorRight;


    public Vector3 vel = Vector3.zero;
    public Vector3 pos = Vector3.zero;
    public bool resetPos = false;


    void Start()
    {
        cc = this.GetComponent<CharacterController>();
        anim = this.GetComponent<Animator>();
        collider = this.GetComponent<CapsuleCollider>();
        handPosition = GameObject.Find("Hand.l_end");
        GameObject butter = GameObject.Find("butterProjectile");
        butterProjectile = butter.GetComponent<Rigidbody>();
        butter.SetActive(false);
        fillBar = GameObject.Find("FillBar").GetComponent<RectTransform>();
        startAnchorLeft = new Vector2(0.026f, 0);
        endAnchorLeft = Vector2.zero;
        startAnchorRight = new Vector2(0.045f,0.12f);
        endAnchorRight = new Vector2(0.3f, 0.12f);
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

        if (facing.x != 0f || facing.y != 0f) {
            Vector3 forward = this.transform.forward;
            if (falling || midJump) {
                forward *= midAirVelocity;
                vel.x += forward.x;
                vel.z += forward.z;
            } else {
                vel.x += forward.x * speedMultiplier;
                vel.z += forward.z * speedMultiplier;
            }
        }

        anim.SetFloat("fallSpeed", vel.y);

        if (Input.GetButtonDown("Fire1") && !recharging) {
            anim.SetBool("Throw", true);
        }
        


        this.transform.rotation = Quaternion.Euler(0f, rot, 0f);

        if (onPlatform) {
            if ((MovingPlatform.transform.position - oldPlatformPos).magnitude < 10) {
                vel.x += (MovingPlatform.transform.position.x - oldPlatformPos.x) / Time.deltaTime;
                vel.z += (MovingPlatform.transform.position.z - oldPlatformPos.z) / Time.deltaTime;
            }
            oldPlatformPos = MovingPlatform.transform.position;
            
        }

        if (recharging) {
            fillBar.anchorMin = Vector2.Lerp(startAnchorLeft,endAnchorLeft, readyTime/rechargeTime);
            fillBar.anchorMax = Vector2.Lerp(startAnchorRight,endAnchorRight, readyTime/rechargeTime);
            if (readyTime >= rechargeTime) {
                recharging = false;
            }
            readyTime += Time.deltaTime;
        }
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
        vel.x = 0f;
        vel.z = 0f;

        // if (falling || midJump)
        //     cc.Move(new Vector3(vel.x*Time.deltaTime, (vel.y-cc.velocity.y)*Time.deltaTime, vel.z*Time.deltaTime));
        // else
        //     cc.Move(new Vector3(0f, (vel.y-cc.velocity.y)*Time.deltaTime, 0f));
    }



    void OnCollisionEnter(Collision c) {
        if(c.gameObject.CompareTag("MovingPlatform")) {
            MovingPlatform = c.gameObject;
            onPlatform = true;
        }
    }

    void OnCollisionExit(Collision c) {
        if(c.gameObject.CompareTag("MovingPlatform")) {
            MovingPlatform = null;
            onPlatform = false;
            oldPlatformPos = Vector3.down * -40;
        }
    } 

    public void ThrowButter() {
        thisProjectile = Instantiate<Rigidbody>(butterProjectile, handPosition.transform);
        this.thisProjectile.gameObject.SetActive(true);
        thisProjectile.isKinematic = false;
        thisProjectile.gameObject.transform.parent = null;
        thisProjectile.AddForce(Vector3.up*80 + this.transform.forward*projectileForce);
        thisProjectile.AddTorque(Random.onUnitSphere*20);
        recharging = true;
        readyTime = 0f;
    }

}
