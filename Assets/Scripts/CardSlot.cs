using SuperPupSystems.Helper;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSlot : MonoBehaviour, IDropHandler
{
    //public DragnDrop card;
    private void Awake()
    {

    }
    public void OnDrop(PointerEventData _data) 
    {
        Debug.Log("OnDrop" + _data.pointerDrag.gameObject);
        if (_data.pointerDrag.tag == "Enemy");
        {
           _data.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
           //_data.pointerDrag.GetComponent<DragnDrop>().use.targetHealth = _data.pointerDrag.gameObject;
           _data.pointerDrag.GetComponent<DragnDrop>().use.TryToPlayCard();

        }
        _data.pointerDrag.GetComponent<CanvasGroup>().alpha = 1.0f;
        _data.pointerDrag.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
