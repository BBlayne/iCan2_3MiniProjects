using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
    public GameObject cubeToWalkOn = null;

    int width = 30;
    int length = 12;
    // Use this for initialization
    private void Start()
    {
        if (cubeToWalkOn)
        {
            MakeFloor();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void MakeFloor()
    {
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (i % 2 == 0 && j % 2 == 0)
                {
                    Vector3 pos = new Vector3(i, -1, j);
                    Instantiate(cubeToWalkOn, pos, Quaternion.identity);
                }

            }
        }
    }
}
