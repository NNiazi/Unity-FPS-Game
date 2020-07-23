using UnityEngine;
using System.Collections;

public class BulletProjectile : MonoBehaviour
{
    public Rigidbody BulletPre;
    public Transform muzzle;


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Rigidbody rocketInstance;
            rocketInstance = Instantiate(BulletPre, muzzle.position, muzzle.rotation) as Rigidbody;
            rocketInstance.AddForce(muzzle.forward * 16000);
            Debug.Log("BulletFired");
        }
    }
}




