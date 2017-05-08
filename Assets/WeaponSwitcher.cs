using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {

    public GameObject HC;

	// Use this for initialization
	void Start () {
        HC = GameObject.Find("HandsController");
	}
	
	// Update is called once per frame
	void Update () {
		if (SixenseInput.Controllers[0].GetButtonDown(SixenseButtons.ONE))
        {
            HC.GetComponent<Slingshot>().enabled = true;
            HC.GetComponent<BowAndArrow>().enabled = false;
            HC.GetComponent<ThrowBall>().enabled = false;
        }
        if (SixenseInput.Controllers[0].GetButtonDown(SixenseButtons.TWO))
        {
            HC.GetComponent<Slingshot>().enabled = false;
            HC.GetComponent<BowAndArrow>().enabled = true;
            HC.GetComponent<ThrowBall>().enabled = false;
        }
        if (SixenseInput.Controllers[0].GetButtonDown(SixenseButtons.THREE))
        {
            HC.GetComponent<Slingshot>().enabled = false;
            HC.GetComponent<BowAndArrow>().enabled = false;
            HC.GetComponent<ThrowBall>().enabled = true;
        }
	}
}
