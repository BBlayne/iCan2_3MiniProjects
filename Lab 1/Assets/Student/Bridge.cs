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

	}
}