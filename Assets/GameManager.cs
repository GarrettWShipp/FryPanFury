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

}
