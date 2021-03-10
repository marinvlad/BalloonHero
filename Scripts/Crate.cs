using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            GetComponent<Rigidbody>().AddExplosionForce(20000f,transform.position,50f);
            Destroy(gameObject);
        }
    }
}
