using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    public GameObject objectToSpawn = null;

    // Use this for initialization
    private void Start()
    {
        if (objectToSpawn)
        {
            SpawnObjects();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SpawnObjects()
    {
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
