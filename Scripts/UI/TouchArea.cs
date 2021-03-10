using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchArea : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
   [SerializeField] private CustomInputSystem _customInputSystem;


   public void OnPointerDown(PointerEventData eventData)
   {
      _customInputSystem.onPointerDownEvent?.Invoke();
   }

   public void OnPointerUp(PointerEventData eventData)
   {
      _customInputSystem.onPointerUpEvent?.Invoke();
   }

   public void OnBeginDrag(PointerEventData eventData)
   {
      _customInputSystem.onBeginDragEvent?.Invoke(eventData);
   }

   public void OnEndDrag(PointerEventData eventData)
   {
      _customInputSystem.onEndDragEvent?.Invoke(eventData);
   }

   public void OnDrag(PointerEventData eventData)
   {
      _customInputSystem.onDragEvent?.Invoke(eventData);
   }
}
