using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    GameObject[] pauseObjects;
	public Text bricks;
	private static int brickCounter;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("Pause");
        hidePaused();
		brickCount();
    }
	
	public void brickCount()
	{
		brickCounter = PlaceBrick.MaxBrickCount;
		//Debug.Log("Current Brick Count: " + brickCounter);
		bricks.text = "Bricks " + brickCounter + "/15";
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
		brickCount();
		
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
