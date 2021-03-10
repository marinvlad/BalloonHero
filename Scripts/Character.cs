using System;
using System.Collections;
using System.Collections.Generic;
using Systems.Events;
using Systems.Utility;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Action onBulletHit;
    public bool isFloating;

    private void Awake()
    {
        isFloating = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            GetComponent<Animator>().enabled = false;
            onBulletHit.Fire();
        }
    }
}
