using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    GameObject[] pauseObjects;
	public Text bricks;
	public Text time;
	private static int brickCounter;
	private float timeLeft = 60.0f;
    public GameObject overwatch;

    // Use this for initialization
    void Start()
    {
        overwatch = GameObject.Find("BGM");
        DontDestroyOnLoad(overwatch);
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("Pause");
        hidePaused();
        if (Application.loadedLevelName.Equals("stage1"))
        {
            brickCount();
            countDown();
        } else
        {
            GameObject.Find("Bricks").SetActive(false);
            GameObject.Find("Time").SetActive(false);
        }
    }
	
	public void brickCount()
	{
		brickCounter = PlaceBrick.MaxBrickCount;
		//Debug.Log("Current Brick Count: " + brickCounter);
		bricks.text = "Bricks " + brickCounter + "/15";
	}
	
	public void countDown()
	{
		timeLeft -= Time.deltaTime;
		time.text = "Time Left: " + Mathf.Round(timeLeft);
		//Debug.Log("Time Left: " + timeLeft);
		if(timeLeft < 0){
			Application.LoadLevel("stage2");
		}
	}

    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    public void kill()
    {
        Application.Quit();
    }

    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Application.loadedLevelName);
        if (Application.loadedLevelName.Equals("stage1"))
        {
            brickCount();
            countDown();
        }
		
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }


}
