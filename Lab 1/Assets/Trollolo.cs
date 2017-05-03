using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trollolo : MonoBehaviour {
    float duration = 5;
    float timer = 0;
    Text timerText;
    int maxNumCubes = 10;
    bool isTimer = true;

	// Use this for initialization
	private void Start () 
	{
        //GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
        timer = duration;
        timerText = GameObject.Find("TimerText").GetComponent<Text>();

        if (timerText == null)
        {
            Debug.LogError("Error: Unable to find TimerText.");
        }
    }
	
	// Update is called once per frame
	private void Update () 
	{        
        if (isTimer)
        {
            print(isTimer);
            timer -= Time.deltaTime;
        }
            

        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        timerText.text =
            string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timer <= 0)
        {
            isTimer = false;
            timer = 0;
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
            if (cubes.Length > maxNumCubes)
            {              
                foreach (GameObject cube in cubes)
                {
                    Destroy(cube);
                }
            }
        }
	}
}
