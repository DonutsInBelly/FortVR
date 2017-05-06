using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBrick : MonoBehaviour {

    public GameObject Brick;
    public GameObject RightHand;

	// Use this for initialization
	void Start () {
        RightHand = GameObject.Find("Hand - Right");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1))
        {
            Instantiate(Brick, RightHand.transform.position, Quaternion.identity);
        }
	}
}
