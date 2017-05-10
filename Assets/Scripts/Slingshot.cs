using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {

    public GameObject Ball;
    public GameObject LeftHand;
    public GameObject RightHand;
    private Vector3 prevPos = Vector3.one;
    private bool isFired = false;
    private float distance;

    // Use this for initialization
    void Start () {
        LeftHand = GameObject.Find("Hand - Left");
        RightHand = GameObject.Find("Hand - Right");
    }

    // Update is called once per frame
    void Update () {
        distance = 10 * Vector3.Distance(LeftHand.transform.position, RightHand.transform.position);
		if (SixenseInput.Controllers[1].Trigger != 0f)
        {
            if (!isFired)
            {
                GameObject LaunchedBall = Instantiate(Ball, RightHand.transform.position, RightHand.transform.rotation);
                LaunchedBall.GetComponent<Rigidbody>().AddForce(RightHand.transform.forward * 100 * distance);
                Destroy(LaunchedBall, 2.0f);
                isFired = true;
            }
        }
        if (SixenseInput.Controllers[1].Trigger == 0f)
        {
            isFired = false;
        }
	}
}
