using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour {
    public GameObject cubeToWalkOn = null;
	// Use this for initialization
	private void Start () 
	{
		if (cubeToWalkOn)
        {
            MakeBridge();
        }
	}

    private void MakeBridge()
    {
        for (int i = 0; i < 60; i++)
        {
            if (i % 2 == 0)
            {
                Vector3 pos = new Vector3(0, -1, i);
                Instantiate(cubeToWalkOn, pos, Quaternion.identity);
            }
        }
    }
	
	// Update is called once per frame
	private void Update () 
	{
		
	}
}
