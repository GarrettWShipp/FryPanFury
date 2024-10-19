using SuperPupSystems.Helper;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UseCard : MonoBehaviour
{
    public SimpleCardScript cardScript;

    private PlayerManager m_playerManager;
    [HideInInspector] public Health targetHealth;
    [HideInInspector] public EnemyManager enemyManager;
    [HideInInspector] public CardManager cardManager;

    private int m_cardMana;
    private int m_playerMana;

    [HideInInspector] public int cardAttack;
    [HideInInspector] public int cardAttackBuffed;
    [HideInInspector] public int cardAttackDebuffed;
    [HideInInspector] public int cardDefense;
    [HideInInspector] public bool beingDragged;

    private int m_tempAttack;
    private int m_tempDefense;
    
    [HideInInspector] public InfoType infoType;

    public GameObject hand;


    // Start is called before the first frame update
    void Awake()
    {
        infoType = cardScript.infoType;
        m_cardMana = cardScript.manaCost;

        cardAttack = cardScript.attack;
        cardDefense = cardScript.Defensive;
        
    }
    private void Start()
    {
        m_playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        cardManager = GameObject.FindGameObjectWithTag("CardManager").GetComponent<CardManager>();
        cardAttackDebuffed = cardAttack / 2;
        cardAttackBuffed = cardAttack * 2;
    }

    // Update is called once per frame
    void Update()
    {

        if (m_playerManager == null) 
        {
            m_playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        }
        m_playerMana = m_playerManager.curMana;
        if (m_playerManager.isBuffed)
        {
            cardAttack = cardAttackBuffed;
        }
        else
        {
            cardAttack = cardScript.attack;
        }

        if (m_playerManager.isDebuffed)
        {
            cardAttack = cardAttackDebuffed;
        }
        else
        {
            cardAttack = cardScript.attack;
        }
    }

    public void TryToPlayCard()
    {
        Debug.Log("Tried to play card");
        if (m_playerMana >= m_cardMana)
        {
            Debug.Log("Check " + enemyManager);
            if(infoType.attack == true)
            {
                if (enemyManager.defense > 0)
                {
                    m_tempDefense = enemyManager.defense - cardAttack;
                    m_tempAttack = cardAttack - enemyManager.defense;

                    cardAttack = m_tempAttack;
                    enemyManager.defense = m_tempDefense;
                }
                if(cardAttack < 0)
                {
                    cardAttack = 0;
                }
                if (enemyManager.defense <= 0)
                {
                    enemyManager.defense = 0;
                    if (m_playerManager.isDebuffed)
                    {
                        targetHealth.Damage(cardAttack);
                    }
                    if (m_playerManager.isBuffed)
                    {
                        targetHealth.Damage(cardAttack);
                    }
                    if (!m_playerManager.isBuffed && !m_playerManager.isDebuffed)
                        targetHealth.Damage(cardAttack);
                    Debug.Log("" +  cardAttack);
                }
                Debug.Log("Played card");

                cardManager.UseCard(gameObject);
            }
            if(infoType.deffense == true)
            {

                m_playerManager.defense += cardDefense;
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
            m_playerManager.curMana -= m_cardMana;
        }

        if (m_playerMana < m_cardMana)
        {
            Debug.Log("You don't have the mana to play this card");
            Debug.Log("Card mana is " + m_cardMana);
            Debug.Log("your mana is " + m_playerMana);
        }
    }

   
}
