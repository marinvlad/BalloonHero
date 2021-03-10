using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    [SerializeField] private GameObject _levelIndicator;
    [SerializeField] private Text _pressToStart;
    [SerializeField] private Image _pressToStartImage;
    [SerializeField] private CustomInputSystem _customInputSystem;

    private void Awake()
    {
        _pressToStart.DOFade(0, 2f).SetLoops(-1, LoopType.Yoyo);
        _pressToStartImage.rectTransform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f).SetLoops(-1,LoopType.Yoyo);
    }

    private void OnEnable()
    {
        _customInputSystem.onPointerDownEvent += HideMenu;
    }

    private void OnDisable()
    {
        _customInputSystem.onPointerUpEvent -= HideMenu;
    }

    private void HideMenu()
    {
        _levelIndicator.SetActive(true);
        gameObject.SetActive(false);
    }

}
