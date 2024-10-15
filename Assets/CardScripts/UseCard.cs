using SuperPupSystems.Helper;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UseCard : MonoBehaviour
{
    public SimpleCardScript cardScript;

    [HideInInspector] public PlayerManager playerManager;
    [HideInInspector] public Health targetHealth;
    [HideInInspector]public EnemyManager enemyManager;
    [HideInInspector] public CardManager cardManager;

    private int m_cardMana;
    private int m_playerMana;

    private int m_cardAttack;
    private int m_cardDefense;
    
    [HideInInspector] public InfoType infoType;

    public GameObject hand;


    // Start is called before the first frame update
    void Start()
    {
        infoType = cardScript.infoType;
        m_cardMana = cardScript.manaCost;

        m_cardAttack = cardScript.attack;
        m_cardDefense = cardScript.Defensive;
        playerManager = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
        cardManager = GameObject.FindWithTag("CardManager").GetComponent<CardManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
            m_playerMana = playerManager.curMana;
    }

    public void TryToPlayCard()
    {
        Debug.Log("Tried to play card");
        if (m_playerMana >= m_cardMana)
        {

            if(infoType.attack == true)
            {
                if (enemyManager.defense > 0)
                {
                    enemyManager.defense -= m_cardAttack;
                }
                if (enemyManager.defense <= 0)
                {
                    targetHealth.Damage(m_cardAttack + enemyManager.defense);
                }
                Debug.Log("Played card");

                cardManager.UseCard(gameObject);
            }
            if(infoType.deffense == true)
            {

                playerManager.defense += m_cardDefense;
                Debug.Log("Played card");

                cardManager.UseCard(gameObject);

            }
            if(infoType.buff == true)
            {
                Debug.Log("Played card");

                cardManager.UseCard(gameObject);
                return;
            }
            if (infoType.debuff == true)
            {
                Debug.Log("Played card");

                cardManager.UseCard(gameObject);
                return;

            }
            playerManager.curMana -= m_cardMana;
        }

        if (m_playerMana < m_cardMana)
        {
            Debug.Log("You don't have the mana to play this card");
            Debug.Log("Card mana is " + m_cardMana);
            Debug.Log("your mana is " + m_playerMana);
        }
    }

   
}
