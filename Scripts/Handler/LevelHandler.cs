using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Systems.Events;
using Systems.ReactiveVariables;
using DG.Tweening;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private IntEvent _onPlatformEnd;
    [SerializeField] private List<PlatformHandler> _platforms;
    [SerializeField] private FloatVariable _levelProgress;
    [SerializeField] private SimpleEvent _onLevelEnd;
    [SerializeField] private SimpleEvent _onLevelSuccess;
    [SerializeField] private IntEvent _onEnemyArrest;
    [SerializeField] private GameObject _policeman;
    
    private int _currentPlatformIndex;

    private void Awake()
    {
        _levelProgress.Value = 0;
        foreach (var platfrom in _platforms)
        {
            platfrom.onComplete = UpdateCurrentPlaltform;
            _currentPlatformIndex = 0;
        }
    }

    private void OnEnable()
    {
        _onEnemyArrest.Subscribe(ArrestEnemies);
    }

    private void OnDisable()
    {
        _onEnemyArrest.Unsubscribe(ArrestEnemies);
    }

    private void UpdateCurrentPlaltform()
    {
        _currentPlatformIndex = _platforms.Count(e=>e.NoActiveEnemies == e.GetNoEnemies);
        _levelProgress.Value = (float)_currentPlatformIndex / _platforms.Count;
        _onPlatformEnd.Invoke(_currentPlatformIndex);
        if (_currentPlatformIndex == _platforms.Count)
        {
            _onPlatformEnd.Invoke(++_currentPlatformIndex);
            _onLevelEnd.Invoke();
        }
    }

    private void ArrestEnemies(int noEnemies)
    {
        if (noEnemies == _platforms.Sum((e) => e.NoActiveEnemies))
        {
            print("Do confetti effect!" + noEnemies);
            _onLevelSuccess.Invoke();
            _policeman.SetActive(true);
            Camera.main.transform.DOMove(_policeman.transform.position - new Vector3(0,-2,5), 0.5f);
        }
    }
}
