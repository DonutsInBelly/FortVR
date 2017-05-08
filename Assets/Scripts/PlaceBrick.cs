using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBrick : MonoBehaviour {

    public GameObject Brick;
    public GameObject RightHand;
	public int MaxBrickCount = 0;
	private GameObject instance;

	// Use this for initialization
	void Start () {
        RightHand = GameObject.Find("Hand - Right");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(1))
        {
            instance = Instantiate(Brick, RightHand.transform.position, Quaternion.identity);
			instance.name = "brickSpawn";
			MaxBrickCount += 1;
			cloneCounter();
        }
		if (Input.GetMouseButton(1) && instance){
			instance.transform.position = RightHand.transform.position;
			//instance.transform.position.z = 10;
		}
		if (Input.GetMouseButtonUp(1) && instance){
			instance = null;
		}
	}
	
	// Keep track of clones
	void cloneCounter() {
		if(MaxBrickCount == 15){
			Destroy(GameObject.Find("brickSpawn"));
			MaxBrickCount -= 1;
		}
	}
}