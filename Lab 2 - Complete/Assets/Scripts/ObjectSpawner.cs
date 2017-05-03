using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    public GameObject objectToSpawn = null;
    public bool wasClicked = false;

    private void OnEnable()
    {
        GenericButton.OnButtonDown += SpawnObjects;
    }

    private void OnDisable()
    {
        GenericButton.OnButtonDown -= SpawnObjects;
    }

    // Use this for initialization
    private void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SpawnObjects()
    {
        if (!objectToSpawn)
        {
            return;
        }

        if (wasClicked)
            return;

        wasClicked = true;

        StartCoroutine(SpawnObjects(10, 25, GameController.Instance.maxScore));
    }

    IEnumerator SpawnObjects(int x, int y, int max)
    {
        for (int i = 0; i < max; i++)
        {
            Random.InitState((int)System.DateTime.Now.Ticks);
            int _x = Random.Range(0, x);
            int _y = Random.Range(0, y);

            Vector3 pos = new Vector3(_x, 20, _y);
            Instantiate(objectToSpawn, pos, Random.rotation);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
