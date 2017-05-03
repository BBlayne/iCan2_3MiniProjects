using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBall : MonoBehaviour {
    public GameObject colouredBall = null;

    public string ballDispenserName = "BallDispenserBlue";

    public Animator anim;

    Transform ballDispenser = null;

    private void Start()
    {
        ballDispenser = GameObject.Find(ballDispenserName).transform;
    }

    private void OnTriggerExit(Collider other)
    {
        PlayAnimation(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayAnimation(true);
        DropTheBall();
    }

    private void DropTheBall()
    {
        if (colouredBall == null)
        {
            // Throw warning message.
        }
        else
        {

            float RandomX = Random.Range(0, 2) - 1;
            float RandomZ = Random.Range(0, 2) - 1;
            Vector3 pos = ballDispenser.position;
            pos.x += RandomX;
            pos.z += RandomZ;
            Instantiate(colouredBall, pos, Random.rotation);
        }
    }

    private void PlayAnimation(bool trigger)
    {
        if (trigger)
            anim.SetTrigger("isPressed");
        else
            anim.SetTrigger("isReleased");
    }
}
