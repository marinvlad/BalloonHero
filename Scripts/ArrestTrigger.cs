using System;
using System.Collections;
using System.Collections.Generic;
using Systems.Events;
using UnityEngine;

public class ArrestTrigger : MonoBehaviour
{
    [SerializeField] private IntEvent _onEnemyArrest;
    private int _arrestedEnemies;

    private void Awake()
    {
        _arrestedEnemies = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ArrestTag"))
        {
            _arrestedEnemies++;
            _onEnemyArrest.Invoke(_arrestedEnemies);
        }
    }
}
