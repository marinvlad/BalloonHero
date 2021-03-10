using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateWeapon : MonoBehaviour
{
    [SerializeField] private CustomInputSystem _customInputSystem;
    [SerializeField] private LayerMask _ignoreMask;

    private void OnEnable()
    {
        _customInputSystem.onDragEvent += Rotate;
        _customInputSystem.onPointerDownEvent += UpdateRotation;
    }

    private void OnDisable()
    {
        _customInputSystem.onDragEvent -= Rotate;
        _customInputSystem.onPointerDownEvent -= UpdateRotation;
    }

    private void Rotate(PointerEventData eventData)
    {
        var mousePoisition = eventData.position;
        mousePoisition.y += 250;
        var ray = Camera.main.ScreenPointToRay(mousePoisition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity,~_ignoreMask))
        {
            transform.LookAt(hit.point);
        }
    }

    private void UpdateRotation()
    {
        var mousePoisition = Input.mousePosition;
        mousePoisition.y += 250;
        var ray = Camera.main.ScreenPointToRay(mousePoisition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~_ignoreMask))
        {
            transform.LookAt(hit.point);
        }
    }
}