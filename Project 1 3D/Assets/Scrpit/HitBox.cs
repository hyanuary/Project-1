using UnityEngine;
using System.Collections;

public class HitBox : MonoBehaviour {

    private Transform hitTransform;

    Enemy enemy;
    public Vector3 move1;

    public float moveSpeed = 5.0f;
    public bool move = false;

	// Use this for initialization
	void Start () {
        hitTransform = this.transform;
       /* enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        move1 = transform.position - enemy.transform.position;*/
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        if (move == true)
        {
            hitTransform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
    }


    void OnCollisionEnter (Collision collider)
    {
        if (collider.gameObject.tag == "Player")
            Destroy(this.gameObject);
    }
}
