using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletSpawnPosition;
    [SerializeField] private CustomInputSystem _customInputSystem;

    private GameObject _bulletInstance;
    private void OnEnable()
    {
        _customInputSystem.onPointerDownEvent += SpawnBulletInPosition;
        _customInputSystem.onPointerUpEvent += DestroyBulletOnShoot;
    }

    private void OnDisable()
    {
        _customInputSystem.onPointerDownEvent -= SpawnBulletInPosition;
        _customInputSystem.onPointerUpEvent -= DestroyBulletOnShoot;
    }

    private void SpawnBulletInPosition()
    {
        _bulletInstance = Instantiate(_bullet, _bulletSpawnPosition.position, _bulletSpawnPosition.rotation);
        _bulletInstance.GetComponent<Rigidbody>().isKinematic = true;
        _bulletInstance.transform.SetParent(transform);
    }

    private void DestroyBulletOnShoot()
    {
        Destroy(_bulletInstance);
    }
}
