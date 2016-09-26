using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private Transform enemyTransform;

    public float hp = 1.0f;
    public float moveSpeed = 5.0f;
    public bool move = false;
    

    Player player;

	// Use this for initialization
	void Start () {

        enemyTransform = this.transform;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	
	}

	// Update is called once per frame
	void Update () {
        Move();

        if (hp <= 0)
            Destroy(this.gameObject);
	}

    //moving the enemy when the character is near
    void Move ()
    {
        if(move == true)
        {
            enemyTransform.Translate(-moveSpeed * Time.deltaTime, 0,0);
        }
    }

    //when enemy hit the player
    void OnCollisionEnter(Collision collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            player.hp -= 1;
        }
        //if(collider.gameObject.tag == )
    }
}
