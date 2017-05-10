using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlaceBrick : MonoBehaviour {

    public GameObject Brick;
    public GameObject RightHand;
    public GameObject fps;
	public static int MaxBrickCount = 0;
	private GameObject instance;
    private bool isFired;

	// Use this for initialization
	void Start () {
        //RightHand = GameObject.Find("Hand - Right");
		RightHand = GameObject.Find("FirstPersonCharacter");
        fps = GameObject.Find("FPSController");
	}
	
	// Update is called once per frame
	void Update () {
        if (fps.GetComponent<FirstPersonController>().DebugMode)
        {
            if (Input.GetMouseButtonDown(1))
            {
                instance = Instantiate(Brick, RightHand.transform.position, Quaternion.identity);
                instance.name = "brickSpawn";
                DontDestroyOnLoad(instance);
                MaxBrickCount++;
                cloneCounter();
            }
            if (Input.GetMouseButton(1) && instance)
            {
                instance.transform.position = RightHand.transform.position;
                //Vector3 tmp = instance.transform.position;
                //tmp.z += 3;
                //instance.transform.position = tmp;
                instance.transform.position = RightHand.transform.position + RightHand.transform.forward * 3;
                if (instance.transform.position.y < 1.0f)
                {
                    float distanceFromSurface = Mathf.Abs(instance.transform.position.y);
                    Vector3 correctedPos = new Vector3(instance.transform.position.x, instance.transform.position.y + distanceFromSurface + 1, instance.transform.position.z);
                    instance.transform.position = correctedPos;
                }
                //instance.transform.position.Set(instance.transform.position.x, instance.transform.position.y, instance.transform.position.z + 3);
            }
            if (Input.GetMouseButtonUp(1) && instance)
            {
                instance = null;
            }
        } else
        {
            if (SixenseInput.Controllers[1].Trigger != 0f)
            {
                if (!isFired)
                {
                    instance = Instantiate(Brick, RightHand.transform.position, Quaternion.identity);
                    instance.name = "brickSpawn";
                    DontDestroyOnLoad(instance);
                    MaxBrickCount++;
                    cloneCounter();
                    isFired = true;
                }
                
            }
            if (SixenseInput.Controllers[1].Trigger != 0f && instance)
            {
                instance.transform.position = RightHand.transform.position;
                //Vector3 tmp = instance.transform.position;
                //tmp.z += 3;
                //instance.transform.position = tmp;
                instance.transform.position = RightHand.transform.position + RightHand.transform.forward * 3;
                if (instance.transform.position.y < 1.0f)
                {
                    float distanceFromSurface = Mathf.Abs(instance.transform.position.y);
                    Vector3 correctedPos = new Vector3(instance.transform.position.x, instance.transform.position.y + distanceFromSurface + 1, instance.transform.position.z);
                    instance.transform.position = correctedPos;
                }
                //instance.transform.position.Set(instance.transform.position.x, instance.transform.position.y, instance.transform.position.z + 3);
            }
            if (SixenseInput.Controllers[1].Trigger != 0f && instance)
            {
                instance = null;
            }
            if (SixenseInput.Controllers[1].Trigger == 0f)
            {
                isFired = false;
            }
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