using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shoot : MonoBehaviour
{
    [SerializeField] private CustomInputSystem _customInputSystem;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Transform _arrowPosition;

    private void OnEnable()
    {
        _customInputSystem.onPointerUpEvent += ShootBallon;
    }

    private void OnDisable()
    {
        _customInputSystem.onPointerUpEvent -= ShootBallon;
    }

    private void ShootBallon()
    {    
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.y += 250;
        var ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            GameObject b = Instantiate(_bullet, _arrowPosition.position, Quaternion.identity);
            b.transform.LookAt(hit.point);
            b.transform.DOMove(hit.point, 0.2f);
            //b.gameObject.GetComponent<Rigidbody>().velocity = b.transform.forward * Vector3.Distance(_arrowPosition.position,hit.point) * _bulletSpeed;
        }
    }
}