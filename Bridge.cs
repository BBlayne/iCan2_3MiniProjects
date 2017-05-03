using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace iCanComplete
{
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
                if (i % 6 == 0)
                {
                    Vector3 pos = new Vector3(0, -1, i);
                    Instantiate(cubeToWalkOn, pos, Quaternion.identity);
                }
            }
        }
    }

}
