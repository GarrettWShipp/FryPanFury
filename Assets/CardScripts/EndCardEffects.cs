using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCardEffects : MonoBehaviour
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
            m_playCard.discardCard(m_playCard.cardManager.hand.IndexOf(gameObject));
            m_playCard.cardPlayed = false;
        } 
    }
}
