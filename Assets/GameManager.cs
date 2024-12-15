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
        
        cards = m_cardManager.GetComponent<CardManager>().Deck;
        health = m_player.GetComponent<Health>().currentHealth;
        handSize = m_player.GetComponent<PlayerManager>().totalHandSize;
    }

    public void LoadData()
    {
        m_cardManager.GetComponent<CardManager>().Deck = cards;
        m_player.GetComponent<Health>().currentHealth = health;
        m_player.GetComponent<PlayerManager>().totalHandSize = handSize;
    }

}
