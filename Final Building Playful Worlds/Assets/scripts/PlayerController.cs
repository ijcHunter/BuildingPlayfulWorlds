using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float rightKey, leftKey, upKey, downKey;
    private float grabKey;

    public Transform cam;
    public GameObject dragPoint;

    public PhysicMaterial frictionMat;

    public float moveVel, airMoveVel;
    public float maxSpeed, parkourSpeed;
    public float friction, frictionlessTime;
    public float groundMargin = 1.5f;
       public LayerMask ground_layer;

    private bool ground,  isGrabbing, smallGrab;
    private float velX, velY, velZ;
    private float speed;
    //private float tooFast = 1;

    private RaycastHit groundHit;
    private Vector3 groundNormal, slingPoint;
    private float mouseHorizontal;
    private Rigidbody rb;
    private Vector3 currentRotation;
    private Vector3 currentDirection, targetDirection;

    private Rigidbody grabbedObject;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //ground_layer_mask = LayerMask.GetMask("GroundLayer");
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        if (IsGrounded())
        {
            ground = true;
            groundNormal = groundHit.normal;
        }
        else
        {
            ground = false;
            groundNormal = Vector3.up;
        }

        //store the current velocity direction
        currentDirection = rb.velocity.normalized;

        //calculate the current s p e e d
        speed = rb.velocity.magnitude;

        //handle camera and player rotation on the y axis
        mouseHorizontal = Input.GetAxis("Mouse X");
        currentRotation = this.transform.rotation.eulerAngles;
        currentRotation.y += mouseHorizontal;
        this.transform.rotation = Quaternion.Euler(currentRotation);

        //set the values for all the buttons
        CheckInputs();

       

        if (Input.GetMouseButton(0))
        {
            grabKey = 1;
        }
        else
        {
            grabKey = 0;
            isGrabbing = false;
        }


        //set velocity from right and left keys
        velX = rightKey - leftKey;
        velZ = upKey - downKey;

        targetDirection = transform.TransformVector(velX, 0, velZ);
        targetDirection = Vector3.ProjectOnPlane(targetDirection, groundNormal);

       }

    private void FixedUpdate()
    {
        if (grabKey > 0.5f)
        {
            GrabObject();
        }

     

        if (speed < maxSpeed)
        {
            rb.AddForce(targetDirection.normalized * Time.deltaTime * moveVel, ForceMode.VelocityChange);
        }
        else
        {
            Vector3 current = rb.velocity.normalized;

            rb.AddForce((targetDirection - current) * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    void GrabObject()
    {
        if (!isGrabbing)
        {
            StartGrab();
        }
        else HoldGrab();
    }

    void StartGrab()
    {
        RaycastHit grab;
        Physics.Raycast(cam.position, cam.forward, out grab, 70, ground_layer);

        if (grab.collider.tag == "Object")
        {
            grabbedObject = grab.collider.attachedRigidbody;
            grabbedObject.gameObject.GetComponent<Bloem>().opgepakt = true;
            dragPoint.transform.position = grabbedObject.position;
            isGrabbing = true;
            smallGrab = true;
            Debug.Log("Pak Op Bitch");
        }

        if (grab.collider.tag == "ground")
        {

            slingPoint = grab.point;
            isGrabbing = true;
            smallGrab = false;
        }
    }

    void HoldGrab()
    {
             grabbedObject.velocity = ((dragPoint.transform.position - grabbedObject.position) * 2.5f);

    }

    IEnumerator FrictionlessTime()
    {
        frictionMat.dynamicFriction = 0f;
        yield return new WaitForSeconds(frictionlessTime);
        frictionMat.dynamicFriction = friction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            StartCoroutine(FrictionlessTime());
        }

        //when the player lands on the spaceship parent it to stay on it
        if (collision.gameObject.tag == "parent")
        {
            transform.parent = collision.gameObject.transform;
        }
    }



    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
      
        }

        transform.parent = null;
    }

    bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out groundHit, groundMargin, ground_layer))
        {
            return ground = true;
        }
        else return ground = false;
    }

  

    void CheckInputs()
    {

        if (Input.GetKeyUp("right") || Input.GetKeyUp(KeyCode.D))
        {
            rightKey = 0;
        }
        if (Input.GetKeyUp("left") || Input.GetKeyUp(KeyCode.A))
        {
            leftKey = 0;
        }
        if (Input.GetKeyUp("up") || Input.GetKeyUp(KeyCode.W))
        {
            upKey = 0;
        }
        if (Input.GetKeyUp("down") || Input.GetKeyUp(KeyCode.S))
        {
            downKey = 0;
        }
   


 
        if (Input.GetKeyDown("right") || Input.GetKeyDown(KeyCode.D))
        {
            rightKey = 1;
        }
        if (Input.GetKeyDown("left") || Input.GetKeyDown(KeyCode.A))
        {
            leftKey = 1;
        }
        if (Input.GetKeyDown("up") || Input.GetKeyDown(KeyCode.W))
        {
            upKey = 1;
        }
        if (Input.GetKeyDown("down") || Input.GetKeyDown(KeyCode.S))
        {
            downKey = 1;
        }
    
    }
}