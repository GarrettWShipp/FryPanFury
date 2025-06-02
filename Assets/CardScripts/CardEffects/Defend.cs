using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : MonoBehaviour
{
    private PlayCard m_playCard;
    private SimpleCardScript m_cardScript;
    private PlayerManager m_playerManager;

    void Awake()
    {
        m_playCard = gameObject.GetComponent<PlayCard>();
    }
    void Start()
    {
        m_playerManager = m_playCard.playerManager;
        m_cardScript = m_playCard.cardScript;
    }

    void Update()
    {
        if (m_playCard.cardPlayed)
        {
            if (m_playerManager.isRaging)
                {
                    m_playerManager.bonusDmg += m_cardScript.Defensive;
                }
                else
                    m_playerManager.defense += m_cardScript.Defensive;
        } 
    }
}
