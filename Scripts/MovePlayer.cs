using System;
using System.Collections;
using System.Collections.Generic;
using Systems.Events;
using DG.Tweening;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
   [SerializeField] private IntEvent _onPlatformEnd;
   [SerializeField] private List<Transform> _checkPoints;

   private void Awake()
   {
      transform.DOMove(_checkPoints[0].position, 2f);
      transform.DORotate(_checkPoints[0].rotation.eulerAngles, 2f);
   }

   private void OnEnable()
   {
      _onPlatformEnd.Subscribe(MoveToNextPlatform);
   }

   private void OnDisable()
   {
      _onPlatformEnd.Unsubscribe(MoveToNextPlatform);
   }

   private void MoveToNextPlatform(int platformId)
   {
      if(platformId<_checkPoints.Count)
      {
         transform.DORotate(_checkPoints[platformId].rotation.eulerAngles, 2f);
         transform.DOMove(_checkPoints[platformId].position, 2f);
         
      }
   }
}
