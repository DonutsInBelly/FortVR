using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject HC;

	// Use this for initialization
	void Start () {
        HC = GameObject.Find("HandsController");
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "stage1")
        {
            HC.GetComponent<PlaceBrick>().enabled = true;
            HC.GetComponent<PlacePyramid>().enabled = true;
            HC.GetComponent<WeaponSwitcher>().enabled = false;
        } else if (Application.loadedLevelName == "stage2")
        {
            HC.GetComponent<PlaceBrick>().enabled = false;
            HC.GetComponent<PlacePyramid>().enabled = false;
            HC.GetComponent<WeaponSwitcher>().enabled = true;
        }
	}
}
