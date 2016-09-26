using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Transform myTransform;

    // basic variables
    public float hp = 1.0f;
    public float moveSpeed = 10.0f;
    public float jumpingForce = 250.0f;
    private float groundDist;
    public bool shield = false;

    //turning player 
    public GameObject playerModel;
    private int facingDirection = 1;
    private Quaternion facingRotation;

    //enemy
    Enemy enemy;
    Enemy enemy1;
    Enemy enemy2;
    Enemy enemy3;
    Enemy enemy4;
    Enemy enemy5;
    Enemy enemy6;
    Enemy enemy7;
    Enemy enemy8;
    Enemy enemy9;

    HitBox hit;
    HitBox hit1;
    HitBox hit2;
    HitBox hit3;
    HitBox hit4;
    HitBox hit5;
    HitBox hit6;
    HitBox hit7;
    HitBox hit8;
    HitBox hit9;




    // Use this for initialization
    void Start () {
        myTransform = this.transform;

        groundDist = myTransform.GetComponent<Collider>().bounds.extents.y;

        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        enemy1 = GameObject.FindGameObjectWithTag("Enemy1").GetComponent<Enemy>();
        enemy2 = GameObject.FindGameObjectWithTag("Enemy2").GetComponent<Enemy>();
        enemy3 = GameObject.FindGameObjectWithTag("Enemy3").GetComponent<Enemy>();
        enemy4 = GameObject.FindGameObjectWithTag("Enemy4").GetComponent<Enemy>();
        enemy5 = GameObject.FindGameObjectWithTag("Enemy5").GetComponent<Enemy>();
        enemy6 = GameObject.FindGameObjectWithTag("Enemy6").GetComponent<Enemy>();
        enemy7 = GameObject.FindGameObjectWithTag("Enemy7").GetComponent<Enemy>();
        enemy8 = GameObject.FindGameObjectWithTag("Enemy8").GetComponent<Enemy>();
        enemy9 = GameObject.FindGameObjectWithTag("Enemy9").GetComponent<Enemy>();

        hit = GameObject.FindGameObjectWithTag("Hit").GetComponent<HitBox>();
        hit1 = GameObject.FindGameObjectWithTag("Hit1").GetComponent<HitBox>();
        hit2 = GameObject.FindGameObjectWithTag("Hit2").GetComponent<HitBox>();
        hit3 = GameObject.FindGameObjectWithTag("Hit3").GetComponent<HitBox>();
        hit4 = GameObject.FindGameObjectWithTag("Hit4").GetComponent<HitBox>();
        hit5 = GameObject.FindGameObjectWithTag("Hit5").GetComponent<HitBox>();
        hit6 = GameObject.FindGameObjectWithTag("Hit6").GetComponent<HitBox>();
        hit7 = GameObject.FindGameObjectWithTag("Hit7").GetComponent<HitBox>();
        hit8 = GameObject.FindGameObjectWithTag("Hit8").GetComponent<HitBox>();
        hit9 = GameObject.FindGameObjectWithTag("Hit9").GetComponent<HitBox>();

    }
	
	// Update is called once per frame
	void Update () {

        Control();

        if (hp <= 0)
            Destroy(this.gameObject);
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
         //   Debug.Log("jump");
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

    
    void OnCollisionEnter (Collision collider)
    {
        //checking for the enemy to move 
        if (collider.gameObject.tag == "Move")
        {
            //Debug.Log("hit");
            enemy.move = true;
            hit.move = true;
        }
        if (collider.gameObject.tag == "Move1")
        {
            enemy1.move = true;
            hit1.move = true;
        }
        if (collider.gameObject.tag == "Move2")
        {
            enemy2.move = true;
            enemy3.move = true;
            hit2.move = true;
            hit3.move = true;
        }
        if (collider.gameObject.tag == "Move3")
        {
            enemy4.move = true;
            hit4.move = true;
        }
        if (collider.gameObject.tag == "Move4")
        {
            enemy5.move = true;
            enemy6.move = true;
            enemy7.move = true;
            hit5.move = true;

            hit6.move = true;
            hit7.move = true;
        }
        if (collider.gameObject.tag == "Move5")
        {
            enemy8.move = true;
           
            hit8.move = true;
            

        }
        if (collider.gameObject.tag == "Move6")
        {
            enemy9.move = true;
            hit9.move = true;
        }

        //hitting the enemy
        if(collider.gameObject.tag == "Hit")
        {
            enemy.hp -= 1;
        }
        if (collider.gameObject.tag == "Hit1")
        {
            enemy1.hp -= 1;
        }
        if (collider.gameObject.tag == "Hit2")
        {
            enemy2.hp -= 1;
        }
        if (collider.gameObject.tag == "Hit3")
        {
            enemy3.hp -= 1;
        }
        if (collider.gameObject.tag == "Hit4")
        {
            enemy4.hp -= 1;
        }
        if (collider.gameObject.tag == "Hit5")
        {
            enemy5.hp -= 1;
        }
        if (collider.gameObject.tag == "Hit6")
        {
            enemy6.hp -= 1;
        }
        if (collider.gameObject.tag == "Hit7")
        {
            enemy7.hp -= 1;
        }
        if(collider.gameObject.tag == "Hit8")
        {
            enemy8.hp -= 1;
        }
        if (collider.gameObject.tag == "Hit9")
        {
            enemy9.hp -= 1;
        }
        
    }
}
