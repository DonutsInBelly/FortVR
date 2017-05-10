using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class PlacePyramid : MonoBehaviour {

    public GameObject Pyramid;
    public GameObject LeftHand;
    public GameObject fps;
	public int MaxPyramidCount = 0;
	private GameObject instance;
    private bool isFired = false;

	// Use this for initialization
	void Start () {
        LeftHand = GameObject.Find("Hand - Left");
        fps = GameObject.Find("FPSController");
    }

    // Update is called once per frame
    void Update () {
		if (fps.GetComponent<FirstPersonController>().DebugMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                instance = Instantiate(Pyramid, LeftHand.transform.position, Quaternion.identity);
                instance.name = "pyramidSpawn";
                DontDestroyOnLoad(instance);
                MaxPyramidCount++;
                cloneCounter();
            }
            if (Input.GetMouseButton(0) && instance)
            {
                instance.transform.position = LeftHand.transform.position;
                //Vector3 tmp = instance.transform.position;
                //tmp.z += 5;
                //instance.transform.position = tmp;
                instance.transform.position = LeftHand.transform.position + LeftHand.transform.forward * 3;
                if (instance.transform.position.y < 1.0f)
                {
                    float distanceFromSurface = Mathf.Abs(instance.transform.position.y);
                    Vector3 correctedPos = new Vector3(instance.transform.position.x, instance.transform.position.y + distanceFromSurface + 1, instance.transform.position.z);
                    instance.transform.position = correctedPos;
                }
            }
            if (Input.GetMouseButtonUp(0) && instance)
            {
                instance = null;
            }
        } else
        {
            if (SixenseInput.Controllers[0].Trigger != 0f)
            {
                if (!isFired)
                {
                    instance = Instantiate(Pyramid, LeftHand.transform.position, Quaternion.identity);
                    instance.name = "pyramidSpawn";
                    DontDestroyOnLoad(instance);
                    MaxPyramidCount++;
                    cloneCounter();
                    isFired = true;
                }
                if (instance)
                {
                    instance.transform.position = LeftHand.transform.position;
                    //Vector3 tmp = instance.transform.position;
                    //tmp.z += 3;
                    //instance.transform.position = tmp;
                    instance.transform.position = LeftHand.transform.position + LeftHand.transform.forward * 3;
                    if (instance.transform.position.y < 1.0f)
                    {
                        float distanceFromSurface = Mathf.Abs(instance.transform.position.y);
                        Vector3 correctedPos = new Vector3(instance.transform.position.x, instance.transform.position.y + distanceFromSurface + 1, instance.transform.position.z);
                        instance.transform.position = correctedPos;
                    }
                    //instance.transform.position.Set(instance.transform.position.x, instance.transform.position.y, instance.transform.position.z + 3);
                }
            }
            if (SixenseInput.Controllers[0].Trigger != 0f && instance)
            {
                instance.transform.position = LeftHand.transform.position;
                //Vector3 tmp = instance.transform.position;
                //tmp.z += 3;
                //instance.transform.position = tmp;
                instance.transform.position = LeftHand.transform.position + LeftHand.transform.forward * 3;
                if (instance.transform.position.y < 1.0f)
                {
                    float distanceFromSurface = Mathf.Abs(instance.transform.position.y);
                    Vector3 correctedPos = new Vector3(instance.transform.position.x, instance.transform.position.y + distanceFromSurface + 1, instance.transform.position.z);
                    instance.transform.position = correctedPos;
                }
                //instance.transform.position.Set(instance.transform.position.x, instance.transform.position.y, instance.transform.position.z + 3);
            }
            if (SixenseInput.Controllers[0].Trigger != 0f && instance)
            {
                instance = null;
            }
            if (SixenseInput.Controllers[0].Trigger == 0f)
            {
                isFired = false;
            }
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