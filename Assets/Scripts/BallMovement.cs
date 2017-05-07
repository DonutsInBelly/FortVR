using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    private float force = 0.0f;
    private GameObject player;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Hand - Right");
        rb = this.transform.GetComponent<Rigidbody>();
        //rb.AddForce(player.transform.forward * force);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetForce (float speed)
    {
        force = speed;
        rb.AddForce(player.transform.forward * force);
    }
}
