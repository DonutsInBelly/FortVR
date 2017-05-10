using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {

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
		if (SixenseInput.Controllers[0].GetButtonDown(SixenseButtons.ONE))
        {
            HC.GetComponent<Slingshot>().enabled = true;
            HC.GetComponent<BowAndArrow>().enabled = false;
            HC.GetComponent<ThrowBall>().enabled = false;
            slingshot.SetActive(true);
            bow.SetActive(false);
        }
        if (SixenseInput.Controllers[0].GetButtonDown(SixenseButtons.TWO))
        {
            HC.GetComponent<Slingshot>().enabled = false;
            HC.GetComponent<BowAndArrow>().enabled = true;
            HC.GetComponent<ThrowBall>().enabled = false;
            slingshot.SetActive(false);
            bow.SetActive(true);
        }
        if (SixenseInput.Controllers[0].GetButtonDown(SixenseButtons.THREE))
        {
            HC.GetComponent<Slingshot>().enabled = false;
            HC.GetComponent<BowAndArrow>().enabled = false;
            HC.GetComponent<ThrowBall>().enabled = true;
            slingshot.SetActive(false);
            bow.SetActive(false);
        }
	}
}
