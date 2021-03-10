using System;
using System.Collections;
using System.Collections.Generic;
using Systems.Events;
using Systems.ReactiveVariables;
using UnityEngine;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour
{
    [SerializeField] private FloatVariable _levelProgress;
    [SerializeField] private SimpleEvent _onLevelSuccess;
    private Slider _slider;
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _levelProgress.onValueChanged += UpdateLevelProgressBar;
        _onLevelSuccess.Subscribe(Hide);
    }

    private void OnDisable()
    {
        _levelProgress.onValueChanged -= UpdateLevelProgressBar;
        _onLevelSuccess.Unsubscribe(Hide);
    }

    private void UpdateLevelProgressBar()
    {
        _slider.value = _levelProgress.Value;
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
