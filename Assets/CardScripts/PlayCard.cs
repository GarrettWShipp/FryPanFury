using SuperPupSystems.Helper;
using UnityEngine;

public class PlayCard : MonoBehaviour
{
    public SimpleCardScript cardScript;
    [HideInInspector] public PlayerManager playerManager;
    [HideInInspector] public CardManager cardManager;
    [HideInInspector] public Health targetHealth;
    [HideInInspector] public EnemyManager enemyManager;

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
        if (beingDragged)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }
    public void Play()
    {
        if (m_playerMana >= m_cardMana)
        {
            cardPlayed = true;
            playerManager.curMana -= m_cardMana;
        }
    }
    public void discardCard(int index)
    {
        cardManager.discard.Add(cardManager.hand[index]);
        cardManager.hand.Remove(cardManager.hand[index]);
        gameObject.SetActive(false);
    }
}
