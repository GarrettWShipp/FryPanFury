using SuperPupSystems.Helper;
using UnityEngine;

public class PlayCard : MonoBehaviour
{
    public SimpleCardScript cardScript;
    [HideInInspector] public PlayerManager playerManager;
    [HideInInspector] public CardManager cardManager;
    [HideInInspector] public Health targetHealth;
    [HideInInspector] public EnemyManager enemyManager;
    public GameObject prefab;

    private int m_cardMana;
    private int m_playerMana;

    public bool cardPlayed = false;

    [HideInInspector] public bool beingDragged;
    void Awake()
    {
        m_cardMana = cardScript.manaCost;
    }

    void Start()
    {
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        cardManager = GameObject.FindGameObjectWithTag("CardManager").GetComponent<CardManager>();
    }

    void Update()
    {
        if (playerManager == null)
        {
            playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        }
        m_playerMana = playerManager.curMana;
    }
    public void Play()
    {
        if (m_playerMana >= m_cardMana)
        {
            cardPlayed = true;
            discardCard();
            cardPlayed = false;
            Destroy(gameObject);
            playerManager.curMana -= m_cardMana;
        }
    }
    public void discardCard()
    {
        cardManager.Discard.Add(prefab);

        for (int i = 0; i < cardManager.Hand.Count; i++)
        {
            if (cardManager.Hand[i].GetComponent<PlayCard>().cardScript == cardScript)
            {
                cardManager.Hand.Remove(cardManager.Hand[i]);
            }
        }
    }
}
