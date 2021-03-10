using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Crosshair : MonoBehaviour
{
    private Image _crosshairImage;
    [SerializeField] private CustomInputSystem _customInputSystem;

    private void Awake()
    {
        _crosshairImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _customInputSystem.onDragEvent += MoveCrosshair;
        _customInputSystem.onPointerDownEvent += ShowCrosshair;
        _customInputSystem.onPointerUpEvent += HideCrosshair;
    }

    private void OnDisable()
    {
        _customInputSystem.onDragEvent -= MoveCrosshair;
        _customInputSystem.onPointerDownEvent -= ShowCrosshair;
        _customInputSystem.onPointerUpEvent -= HideCrosshair;
    }

    private void MoveCrosshair(PointerEventData eventData)
    {
        Vector3 mousePosition = eventData.position;
        mousePosition.y += 250;
        _crosshairImage.rectTransform.position = mousePosition;
        
        var ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1<<8))
        {
            _crosshairImage.color = Color.white;
        }
        else
        {
            _crosshairImage.color = Color.black;
        }
    }

    private void ShowCrosshair()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.y += 250;
        _crosshairImage.rectTransform.position = mousePosition;
        _crosshairImage.enabled = true;
    }

    private void HideCrosshair()
    {
        _crosshairImage.enabled = false;
    }
}
