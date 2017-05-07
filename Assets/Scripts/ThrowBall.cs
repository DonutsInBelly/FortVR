using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour {

    public GameObject Ball;
    public GameObject RightHand;
    private Vector3 prevPos = Vector3.one;
    private float speed = 5.0f;
    private bool isFired = false;

	// Use this for initialization
	void Start () {
        RightHand = GameObject.Find("Hand - Right");
        //StartCoroutine(CalculateSpeed());
    }
	
	// Update is called once per frame
	void Update () {
        if (SixenseInput.Controllers[1].Trigger != 0f)
        //if (Input.GetMouseButtonDown(1))
        {
            if (!isFired)
            {
                GameObject LaunchedBall = Instantiate(Ball, RightHand.transform.position, RightHand.transform.rotation) as GameObject;
                LaunchedBall.GetComponent<Rigidbody>().AddForce(RightHand.transform.forward * 100 * speed);
                isFired = true;
            }
        }
        if (SixenseInput.Controllers[1].Trigger == 0f)
        {
            isFired = false;
        }
	}

    IEnumerator CalculateSpeed ()
    {
        while (Application.isPlaying)
        {
            prevPos = RightHand.transform.position;
            yield return new WaitForEndOfFrame();
            speed = (prevPos - RightHand.transform.position).magnitude / Time.deltaTime;
            //Debug.Log(speed);
        }
    }
}
