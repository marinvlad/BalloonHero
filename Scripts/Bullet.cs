using System;
using System.Collections;
using System.Collections.Generic;
using Systems.Utility;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _ballonPrefab;
    [SerializeField] private GameObject _explosionPrefab;
    private bool _didHit = false;

    private void OnCollisionEnter(Collision other)
    {
        GameObject _explosionGO = Instantiate(_explosionPrefab, other.contacts[0].point, transform.rotation);
        Destroy(_explosionGO,2f);
        
        
        if (other.gameObject.CompareTag("Enemy") && !_didHit)
        {
            _didHit = true;
            GameObject _ballonGO = Instantiate(_ballonPrefab, other.contacts[0].point, Quaternion.Euler(-90, 0, 0));
            _ballonGO.GetComponent<Rope>().Base = other.gameObject;
            SpringJoint springJoint = _ballonGO.AddComponent<SpringJoint>();
            springJoint.damper = 50;
            springJoint.spring = 50;
            springJoint.connectedBody = other.gameObject.GetComponent<Rigidbody>();
            
            Character characterHit = other.transform.root.gameObject.GetComponent<Character>();
            characterHit.isFloating = true;
            characterHit.onBulletHit.Fire();
        }
        Destroy(gameObject);
    }
}