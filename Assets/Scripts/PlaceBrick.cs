using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBrick : MonoBehaviour {

    public GameObject Brick;
    public GameObject RightHand;
	public static int MaxBrickCount = 0;
	private GameObject instance;

	// Use this for initialization
	void Start () {
        //RightHand = GameObject.Find("Hand - Right");
		RightHand = GameObject.Find("FirstPersonCharacter");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(1))
        {
            instance = Instantiate(Brick, RightHand.transform.position, Quaternion.identity);
			instance.name = "brickSpawn";
            DontDestroyOnLoad(instance);
			MaxBrickCount++;
			cloneCounter();
        }
		if (Input.GetMouseButton(1) && instance){
			instance.transform.position = RightHand.transform.position;
			Vector3 tmp = instance.transform.position;
			tmp.z += 3;
			instance.transform.position = tmp;
		}
		if (Input.GetMouseButtonUp(1) && instance){
			instance = null;
		}
	}
	
	// Keep track of clones
	void cloneCounter() {
		if(MaxBrickCount == 16){
			Destroy(GameObject.Find("brickSpawn"));
			MaxBrickCount--;
		}
	}
}