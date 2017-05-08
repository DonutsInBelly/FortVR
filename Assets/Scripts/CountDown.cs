using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDown : MonoBehaviour
{

	float timeLeft = 60.0f;
	public Text time;
	//public string nextLevel;
	
	void Update(){
		timeLeft -= Time.deltaTime;
		time.text = "Time Left: " + Mathf.Round(timeLeft);
		if(timeLeft < 0){
			Application.LoadLevel("stage2");
		}
	}
}