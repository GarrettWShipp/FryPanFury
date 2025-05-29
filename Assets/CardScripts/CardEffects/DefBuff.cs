using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefBuff : MonoBehaviour
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
            
        } 
    }
}
