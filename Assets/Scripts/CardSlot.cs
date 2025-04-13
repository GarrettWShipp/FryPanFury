using SuperPupSystems.Helper;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class CardSlot : MonoBehaviour, IDropHandler
{
    //public DragnDrop card;
    private Health m_health;
    private EnemyManager m_enemyManager;
    private PlayerManager m_playerManager;
    private void Awake()
    {
        m_health = GetComponent<Health>();
    }

    public void OnDrop(PointerEventData _data) 
    {
        Debug.Log("OnDrop selected target is " + gameObject);
        if (_data.pointerDrag != null);
        {
            if (_data.pointerDrag.GetComponent<UseCard>().infoType.attack == true || _data.pointerDrag.GetComponent<UseCard>().infoType.dmgDebuff == true || _data.pointerDrag.GetComponent<UseCard>().infoType.defDebuff == true)
            {
                if (gameObject.tag == "Enemy")
                {
                    m_enemyManager = GetComponent<EnemyManager>();
                    _data.pointerDrag.GetComponent<UseCard>().enemyManager = m_enemyManager;
                    _data.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                   _data.pointerDrag.GetComponent<UseCard>().targetHealth = m_health;

                   _data.pointerDrag.GetComponent<DragnDrop>().use.TryToPlayCard();
                }
            }
            else
            {
                if(gameObject.tag == "Player")
                {
                    m_playerManager = GetComponent<PlayerManager>();
                    _data.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                    _data.pointerDrag.GetComponent<DragnDrop>().use.TryToPlayCard();
                }
            }
           

        }
        _data.pointerDrag.GetComponent<UseCard>().beingDragged = false;
        _data.pointerDrag.GetComponent<CanvasGroup>().alpha = 1.0f;
        _data.pointerDrag.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
