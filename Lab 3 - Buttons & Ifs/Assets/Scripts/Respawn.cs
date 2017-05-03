using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    public BoundaryMode boundaryMode = BoundaryMode.DO_NOT_EXIT;
    GameObject spawn;

    public enum BoundaryMode
    {
        DO_NOT_EXIT,
        DO_NOT_ENTER
    };

	// Use this for initialization
	private void Start () 
	{
        spawn = GameObject.Find("Respawn");
	}
	
	// Update is called once per frame
	private void Update () 
	{
		
	}

    private void OnTriggerExit(Collider other)
    {
        print(other.name);
        if (boundaryMode == BoundaryMode.DO_NOT_EXIT)
        {
            if (other.CompareTag("Player"))
            {
                other.gameObject.transform.position = spawn.transform.position;
                other.gameObject.transform.rotation = Quaternion.identity;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (boundaryMode == BoundaryMode.DO_NOT_ENTER)
        {
            if (other.CompareTag("Player"))
            {
                other.gameObject.transform.position = spawn.transform.position;
                other.gameObject.transform.rotation = spawn.transform.rotation;
            }
        }
    }
}
