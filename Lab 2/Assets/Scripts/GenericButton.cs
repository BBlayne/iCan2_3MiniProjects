using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericButton : MonoBehaviour {
    public delegate void ButtonAction();
    public static event ButtonAction OnButtonDown;

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();

        if (anim == null)
        {
            Debug.LogError("Animator not found on " + this.gameObject.name);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider other)
    {
        anim.SetTrigger("isReleased");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (OnButtonDown != null)
            OnButtonDown();

        anim.SetTrigger("isPressed");
    }
}
