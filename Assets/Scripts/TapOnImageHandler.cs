using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class TapOnImageHandler : MonoBehaviour, IPointerClickHandler
{
    public Action TapOnImageAction;

    public void OnPointerClick(PointerEventData eventData)
    {
        TapOnImageAction?.Invoke();
    }
}
