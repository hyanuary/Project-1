using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    Player player;

    private Vector3 offset;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        offset = transform.position - player.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + offset;
	
	}
}
