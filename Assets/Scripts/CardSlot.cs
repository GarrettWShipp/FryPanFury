using SuperPupSystems.Helper;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSlot : MonoBehaviour, IDropHandler
{
    //public DragnDrop card;
    private Health m_health;
    private void Awake()
    {
        m_health = GetComponent<Health>();
    }
    public void OnDrop(PointerEventData _data) 
    {
        Debug.Log("OnDrop selected tag: " + _data.pointerDrag.gameObject.tag);
        if (_data.pointerDrag != null);
        {
           _data.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
           _data.pointerDrag.GetComponent<UseCard>().targetHealth = m_health;
           _data.pointerDrag.GetComponent<DragnDrop>().use.TryToPlayCard();

        }
        _data.pointerDrag.GetComponent<CanvasGroup>().alpha = 1.0f;
        _data.pointerDrag.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
