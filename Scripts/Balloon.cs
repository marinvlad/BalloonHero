using System;
using System.Collections;
using System.Collections.Generic;
using Systems.Events;
using Systems.ReactiveVariables;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private SimpleEvent _onLevelEnd;
    private bool _canDestroyBalloons;
    private Vector3 _direction = Vector3.up;

    private void Awake()
    {
        _canDestroyBalloons = false;
    }

    private void OnEnable()
    {
        _onLevelEnd.Subscribe(EnableBalloonDestroy);
    }

    private void OnDisable()
    {
        _onLevelEnd.Unsubscribe(EnableBalloonDestroy);
    }

    private void Update()
    {
        transform.GetComponent<Rigidbody>().velocity = _direction * _speed;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Top"))
        {
            _direction = Vector3.forward;
        }
        if (other.gameObject.CompareTag("Bullet") && _canDestroyBalloons)
        {
            Destroy(gameObject);
        }
    }

    private void EnableBalloonDestroy()
    {
        _canDestroyBalloons = true;
    }
}