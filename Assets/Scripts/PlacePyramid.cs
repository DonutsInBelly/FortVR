using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePyramid : MonoBehaviour {

    public GameObject Pyramid;
    public GameObject LeftHand;
	public int MaxPyramidCount = 0;
	private GameObject instance;

	// Use this for initialization
	void Start () {
        LeftHand = GameObject.Find("Hand - Left");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0))
        {
            instance = Instantiate(Pyramid, LeftHand.transform.position, Quaternion.identity);
			instance.name = "pyramidSpawn";
            DontDestroyOnLoad(instance);
			MaxPyramidCount++;
			cloneCounter();
        }
		if (Input.GetMouseButton(0) && instance){
			instance.transform.position = LeftHand.transform.position;
			Vector3 tmp = instance.transform.position;
			tmp.z += 5;
			instance.transform.position = tmp;
		}
		if (Input.GetMouseButtonUp(0) && instance){
			instance = null;
		}
	}
	
	// Keep track of clones
	void cloneCounter() {
		if(MaxPyramidCount == 2){
			Destroy(GameObject.Find("pyramidSpawn"));
			MaxPyramidCount--;
		}
	}
}