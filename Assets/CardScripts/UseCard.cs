using SuperPupSystems.Helper;
using UnityEngine;

public class UseCard : MonoBehaviour
{
    public SimpleCardScript cardScript;

    public PlayerManager m_playerManager;
    [HideInInspector] public Health targetHealth;
    [HideInInspector] public EnemyManager enemyManager;
    [HideInInspector] public CardManager cardManager;

    private int m_cardMana;
    private int m_playerMana;

    [HideInInspector] public int cardAttack;
    [HideInInspector] public int cardAttackBuffed;
    [HideInInspector] public int cardAttackDebuffed;
    [HideInInspector] public int cardDefenseBuffed;
    [HideInInspector] public int cardDefenseDebuffed;
    [HideInInspector] public int cardDefense;
    [HideInInspector] public bool beingDragged;

    private int m_tempAttack;
    private int m_tempDefense;

    [HideInInspector] public InfoType infoType;

    public GameObject prefab;

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
        cardAttackBuffed = cardAttack * m_playerManager.dmgBuffValue;
        cardAttackDebuffed = cardAttack / m_playerManager.dmgDebuffValue;

        cardDefenseBuffed = cardDefense * m_playerManager.defBuffValue;
        cardDefenseDebuffed = cardDefense / m_playerManager.defDebuffValue;
    }

    // Update is called once per frame
    void Update()
    {

        if (m_playerManager == null)
        {
            m_playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        }
        m_playerMana = m_playerManager.curMana;
        if (m_playerManager.dmgIsBuffed)
        {
            cardAttack = cardAttackBuffed;
        }
        if (m_playerManager.dmgIsDebuffed)
        {
            cardAttack = cardAttackDebuffed;
        }

        if (m_playerManager.dmgIsBuffed && m_playerManager.dmgIsDebuffed)
        {
            cardAttack = cardScript.attack;
        }

        if (!m_playerManager.dmgIsBuffed && !m_playerManager.dmgIsDebuffed)
        {
            cardAttack = cardScript.attack;
        }
    }

    public void TryToPlayCard()
    {
        if (m_playerMana >= m_cardMana)
        {
            if (infoType.attack == true)
            {
                cardAttack += m_playerManager.bonusDmg;
                if (enemyManager.defense > 0)
                {
                    m_tempDefense = enemyManager.defense - cardAttack;
                    m_tempAttack = cardAttack - enemyManager.defense;

                    cardAttack = m_tempAttack;
                    enemyManager.defense = m_tempDefense;
                }
                if (cardAttack < 0)
                {
                    cardAttack = 0;
                }
                if (enemyManager.defense <= 0)
                {
                    enemyManager.defense = 0;
                    targetHealth.Damage(cardAttack);
                    Debug.Log("" + cardAttack);
                }
                m_playerManager.bonusDmg = 0;
                if (m_playerManager.isRaging)
                {
                    m_playerManager.rageCounter--;
                }
            }
            if (infoType.defense == true)
            {
                if (m_playerManager.isRaging)
                {
                    m_playerManager.bonusDmg += cardDefense;
                }
                else
                    m_playerManager.defense += cardDefense;
            }
            if (infoType.dmgBuff == true)
            {
                m_playerManager.dmgIsBuffed = true;
                m_playerManager.dmgBuffCounter += 3;
            }
            if (infoType.defBuff == true)
            {
                m_playerManager.defIsBuffed = true;
                m_playerManager.defBuffCounter += 3;
            }
            if (infoType.defDebuff == true)
            {
                enemyManager.defIsDebuffed = true;
                enemyManager.defDebuffCounter += 3;
            }
            if (infoType.dmgDebuff == true)
            {
                enemyManager.dmgIsDebuffed = true;
                enemyManager.dmgDebuffCounter += 3;
            }
            if (infoType.poisonous == true)
            {
                enemyManager.isPoisoned = true;
                enemyManager.poisonCounter += cardScript.poison;
            }
            if (infoType.fire == true)
            {
                enemyManager.onFire = true;
                enemyManager.fireCounter += cardScript.fire;
            }
            if(infoType.rage == true)
            {
                if (!m_playerManager.isRaging)
                {
                    m_playerManager.rageCounter++;
                }
            }
            cardManager.UseCard(prefab);
            Destroy(gameObject);
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
