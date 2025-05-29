using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private PlayCard m_playCard;
    private SimpleCardScript m_cardScript;
    private PlayerManager m_playerManager;
    private EnemyManager m_enemyManager;

    [HideInInspector] public int cardAttack;

    void Awake()
    {
        m_playCard = gameObject.GetComponent<PlayCard>();
    }
    void Start()
    {
        m_cardScript = m_playCard.cardScript;
        m_playerManager = m_playCard.playerManager;
        cardAttack = m_cardScript.attack;
    }
    void Update()
    {
        if (m_playCard.cardPlayed)
        {
            cardAttack += m_playerManager.bonusDmg;
            if (m_playerManager.dmgIsBuffed)
            {
                cardAttack = cardAttack * m_playerManager.dmgBuffValue;
            }
            if (m_playCard.playerManager.dmgIsDebuffed)
            {
                cardAttack = cardAttack / m_playerManager.dmgDebuffValue;
            }
            if (m_enemyManager.defense > 0)
            {
                m_enemyManager.defense = m_enemyManager.defense - cardAttack;
                cardAttack = cardAttack - m_enemyManager.defense;
            }
            if (cardAttack < 0)
            {
                cardAttack = 0;
            }
            if (m_enemyManager.defense <= 0)
            {
                m_enemyManager.defense = 0;
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
