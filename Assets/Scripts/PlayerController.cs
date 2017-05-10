using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject HC;
    public GameObject bow;
    public GameObject slingshot;

	// Use this for initialization
	void Start () {
        HC = GameObject.Find("HandsController");
        bow = GameObject.Find("Bow00_prefab");
        bow.SetActive(false);
        slingshot = GameObject.Find("Slingshot_prefab");
        slingshot.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName.Equals("stage1"))
        {
            HC.GetComponent<PlaceBrick>().enabled = true;
            HC.GetComponent<PlacePyramid>().enabled = true;
            HC.GetComponent<WeaponSwitcher>().enabled = false;
        } else if (Application.loadedLevelName.Equals("stage2"))
        {
            HC.GetComponent<PlaceBrick>().enabled = false;
            HC.GetComponent<PlacePyramid>().enabled = false;
            HC.GetComponent<WeaponSwitcher>().enabled = true;
        }
	}
}
