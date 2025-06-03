using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private PlayCard m_playCard;
    private SimpleCardScript m_cardScript;
    private PlayerManager m_playerManager;

    [HideInInspector] public int cardAttack;
    private int m_buffTotal;
    private int m_debuffTotal;

    void Awake()
    {
        m_playCard = gameObject.GetComponent<PlayCard>();
    }
    void Start()
    {
        m_cardScript = m_playCard.cardScript;
        m_playerManager = m_playCard.playerManager;
        cardAttack = m_cardScript.attack;
        m_buffTotal = cardAttack * m_playerManager.dmgBuffValue;
        m_debuffTotal = cardAttack / m_playerManager.dmgDebuffValue;
    }
    void Update()
    {
        
        cardAttack += m_playerManager.bonusDmg;
        if (m_playerManager.dmgIsBuffed)
        {
            cardAttack = m_buffTotal;
        }
        if (m_playCard.playerManager.dmgIsDebuffed)
        {
            cardAttack = m_debuffTotal;
        }
        if (m_playerManager.dmgIsBuffed && m_playerManager.dmgIsDebuffed)
        {
            cardAttack = m_cardScript.attack;
        }

        if (!m_playerManager.dmgIsBuffed && !m_playerManager.dmgIsDebuffed)
        {
            cardAttack = m_cardScript.attack;
        }
        if (m_playCard.cardPlayed)
        {
            if (m_playCard.enemyManager.defense > 0)
            {
                m_playCard.enemyManager.defense -= cardAttack;
                cardAttack -= m_playCard.enemyManager.defense;
            }
            if (cardAttack < 0)
            {
                cardAttack = 0;
            }
            if (m_playCard.enemyManager.defense <= 0)
            {
                m_playCard.enemyManager.defense = 0;
                m_playCard.targetHealth.Damage(cardAttack);
                Debug.Log("" + cardAttack);
            }
            m_playerManager.bonusDmg = 0;
            if (m_playerManager.isRaging)
            {
                m_playerManager.rageCounter--;
            }
        } 
    }
}
