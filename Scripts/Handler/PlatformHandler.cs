using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Systems.Events;
using Systems.Utility;
using UnityEngine;

public class PlatformHandler : MonoBehaviour
{
    [SerializeField] private List<Character> enemies = new List<Character>();
    public Action onComplete;
    private int _noActiveEnemies;
    
    private void Awake()
    {
        _noActiveEnemies = 0;
        foreach (var enemy in enemies)
        {
            enemy.onBulletHit = UpdateNoEnemies;
        }
    }

    private void UpdateNoEnemies()
    {
        _noActiveEnemies = enemies.Count((e) => e.isFloating);
        if (_noActiveEnemies == enemies.Count)
        {
           onComplete.Fire();
        }
    }

    public int NoActiveEnemies => _noActiveEnemies;
    public int GetNoEnemies => enemies.Count;
}