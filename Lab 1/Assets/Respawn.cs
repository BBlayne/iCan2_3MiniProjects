using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    GameObject spawn;

	// Use this for initialization
	private void Start () 
	{
        spawn = GameObject.Find("Respawn");
	}
	
	// Update is called once per frame
	private void Update () 
	{
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = spawn.transform.position;
        }
    }
}
