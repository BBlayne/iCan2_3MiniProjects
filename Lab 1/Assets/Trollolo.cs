using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trollolo : MonoBehaviour {
    float duration = 20;
    float timer = 0;

	// Use this for initialization
	private void Start () 
	{
        //GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
        timer = duration;

    }
	
	// Update is called once per frame
	private void Update () 
	{
        timer -= Time.deltaTime;
        print(timer);
        if (timer <= 0)
        {
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
            if (cubes.Length > 5)
            {
                foreach (GameObject cube in cubes)
                {
                    Destroy(cube);
                }
            }

            timer = duration;
        }
	}
}
