using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
    public delegate void ErrorAction(string errorMsg);
    public static event ErrorAction OnError;

    public GameObject cubeToWalkOn = null;
    public GameObject smallCubeToWalkOn = null;

    bool wasClicked = false;

    int width = 30;
    int length = 12;

    private void OnEnable()
    {
        GenericButton.OnButtonDown += MakeFloor;
    }

    private void OnDisable()
    {
        GenericButton.OnButtonDown -= MakeFloor;
    }

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void MakeFloor()
    {
        if (!cubeToWalkOn)
        {
            if (OnError != null)
                OnError("the GameObject variable cubeToWalkOn for " + this.gameObject.name 
                    + " isn't assigned!");

            return;
        }

        if (!smallCubeToWalkOn)
        {
            if (OnError != null)
                OnError("the GameObject variable smallCubeToWalkOn for " + this.gameObject.name
                    + " isn't assigned!");

            return;
        }

        if (wasClicked)
            return;

        wasClicked = true;

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

        for (int i = 1; i < 10; i++)
        {
            for (int j = 0; j < i; j++)
            {
                Vector3 pos = new Vector3(i + 1, j - (0.70f * i), -0.5f);
                Instantiate(smallCubeToWalkOn, pos, Quaternion.identity);
            }
        }

        for (int i = 8; i < 40; i++)
        {
            for (int j = 0; j < i; j++)
            {
                Vector3 pos = new Vector3(10, j - (0.65f * i), i - 8 - 0.5f);
                Instantiate(smallCubeToWalkOn, pos, Quaternion.identity);
            }
        }

        for (int i = 0; i < 10; i++)
        {
            Vector3 pos = new Vector3(i,10,24.5f);
            Instantiate(smallCubeToWalkOn, pos, Quaternion.identity);
        }
    }
}
