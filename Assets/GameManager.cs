using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    private GameObject m_player;
    private GameObject m_cardManager;
    public List<GameObject> cards;
    public int health;
    public int handSize;
    public int floorsCleared;
    public int coins;
    public int numberOfFights;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // Make an instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

    }
    private void Start()
    {
        m_player = GameObject.Find("Player");
        m_cardManager = GameObject.FindWithTag("CardManager");
        LoadData();
    }

    public void GetData()
    {
        cards = m_cardManager.GetComponent<CardManager>().deck;
        health = m_player.GetComponent<Health>().currentHealth;
        handSize = m_player.GetComponent<PlayerManager>().totalHandSize;
    }

    public void LoadData()
    {
        for (int i = 0; i < cards.Count - 1; i++)
        {
            GameObject newCard = Instantiate(cards[i], m_cardManager.GetComponent<CardManager>().cardBar.transform);
            m_cardManager.GetComponent<CardManager>().deck.Add(newCard);
            newCard.SetActive(false);
        }
        m_player.GetComponent<Health>().currentHealth = health;
        m_player.GetComponent<PlayerManager>().totalHandSize = handSize;
        m_player.GetComponent<PlayerManager>().coins = coins;
    }

}
