using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyActivation : MonoBehaviour {

    public Transform player;

    private Animator anim;

    float timeDelay = 1;
    float timeToNextShot = 0;

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 direction = player.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
        if (Vector3.Distance(player.position, transform.position) < 28 && angle < 30)
        {

            direction.y = 0;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.3f);

            anim.SetBool("isIdle", false);
            if (direction.magnitude > 12)
                
            {
                transform.Translate(0, 0, 0.9f);
                anim.SetBool("isRunning", true);
                anim.SetBool("isShooting", false);
            }
            else
            {
                if (timeToNextShot <= 0)
                {
                    timeToNextShot = timeDelay;
                    anim.SetBool("isShooting", true);
                    anim.SetBool("isRunning", false);
                    GameManager.Instance.SetDamage(5);
                }
                else timeToNextShot -= Time.deltaTime;
            }
        }
        else
        {
            if (anim != null)
            {
                anim.SetBool("isIdle", true);
                anim.SetBool("isRunning", false);
                anim.SetBool("isShooting", false);
            }
        }
    }

}

