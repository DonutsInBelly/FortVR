using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAndArrow : MonoBehaviour {

    public GameObject Arrow;
    public GameObject LeftHand;
    public GameObject RightHand;
    //private Vector3 prevPos = Vector3.one;
    private float speed = 5.0f;
    private bool isFired = false;
    private float distance;

    // Use this for initialization
    void Start () {
        LeftHand = GameObject.Find("Hand - Left");
        RightHand = GameObject.Find("Hand - Right");
    }

    // Update is called once per frame
    void Update() {
        distance = 5 * Vector3.Distance(LeftHand.transform.position, RightHand.transform.position);
        Debug.Log(distance);
        if (SixenseInput.Controllers[1].Trigger != 0f)
        {
            if (!isFired)
            {
                GameObject LaunchedArrow = Instantiate(Arrow, RightHand.transform.position, RightHand.transform.rotation);
                //LaunchedArrow.GetComponent<>().//GetComponent<Rigidbody>().AddForce(RightHand.transform.forward * 100 * distance);
                LaunchedArrow.GetComponent<Rigidbody>().AddForce(RightHand.transform.forward * 2000 * distance);
                //LaunchedArrow.GetComponent<Rigidbody>().velocity = RightHand.transform.forward;
                isFired = true;
            }
        }
        if (SixenseInput.Controllers[1].Trigger == 0f)
        {
            isFired = false;
        }
	}
}
