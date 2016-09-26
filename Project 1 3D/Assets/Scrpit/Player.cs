using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Transform myTransform;

    // basic variables
    public float moveSpeed = 10.0f;
    public float jumpingForce = 250.0f;
    private float groundDist;
    public bool shield = false;

    //turning player 
    public GameObject playerModel;
    private int facingDirection = 1;
    private Quaternion facingRotation;

	// Use this for initialization
	void Start () {
        myTransform = this.transform;

        groundDist = myTransform.GetComponent<Collider>().bounds.extents.y;
	
	}
	
	// Update is called once per frame
	void Update () {

        Control();
	}

    void Control ()
    {
        //move right
        if(Input.GetKey("d"))
        {
            myTransform.Translate(0, 0, moveSpeed * Time.deltaTime);
            facingDirection = 1;

            DirectionFacing();
        }

        //move right 
        if(Input.GetKey("a"))
        {
            myTransform.Translate(0, 0, moveSpeed * Time.deltaTime);
            facingDirection = -1;

            DirectionFacing();
        }

        //jumping
        if(Input.GetKey("w") && CheckGrounded () == true )
        {
            Debug.Log("jump");
            myTransform.GetComponent<Rigidbody>().AddForce(0, jumpingForce, 0);
        }
    }

    // applying the transformation for the character moving
    void DirectionFacing()
    {
        //get the current state of the player
        facingRotation = playerModel.transform.rotation;

        if(facingDirection == 1)
        {
            facingRotation.eulerAngles = new Vector3(facingRotation.eulerAngles.x, 90, facingRotation.eulerAngles.z);
        }
        else if(facingDirection == -1)
        {
            facingRotation.eulerAngles = new Vector3(facingRotation.eulerAngles.x, -90, facingRotation.eulerAngles.z);
        }

        playerModel.transform.rotation = facingRotation;
    }

    //raycast down to see if it's hitting the ground
    public bool CheckGrounded()
    {
        return Physics.Raycast(myTransform.position, -Vector3.up, groundDist + 0.1f);
    }
}
