using SuperPupSystems.Helper;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UseCard : MonoBehaviour
{
    public SimpleCardScript cardScript;
    public PlayerManager player;
    public Health targetHealth;
    public EnemyManager enemyManager;

    public CardManager cardManager;

    private int m_cardMana;
    private int m_playerMana;

    private int m_cardAttack;
    private int m_cardDefense;
    
    private InfoType m_infoType;

    public GameObject hand;


    // Start is called before the first frame update
    void Start()
    {
        m_infoType = cardScript.infoType;
        m_cardMana = cardScript.manaCost;

        m_cardAttack = cardScript.attack;
        m_cardDefense = cardScript.Defensive;
    }

    // Update is called once per frame
    void Update()
    {
        
            m_playerMana = player.curMana;
    }

    public void TryToPlayCard()
    {
        Debug.Log("Tried to play card");
        if (m_playerMana >= m_cardMana)
        {
            player.curMana -= m_cardMana;

            if(m_infoType.attack == true)
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
            if(m_infoType.deffense == true)
            {

                player.defense += m_cardDefense;
                Debug.Log("Played card");

                cardManager.UseCard(gameObject);

            }
            if(m_infoType.buff == true)
            {
                Debug.Log("Played card");

                cardManager.UseCard(gameObject);
                return;
            }
            if (m_infoType.debuff == true)
            {
                Debug.Log("Played card");

                cardManager.UseCard(gameObject);
                return;

            }
            //RectTransform picture = GetComponent<RectTransform>();
            //picture.anchoredPosition = new Vector2(807f, -100);
        }

        if (m_playerMana < m_cardMana)
        {
            Debug.Log("You don't have the mana to play this card");
            Debug.Log("Card mana is " + m_cardMana);
            Debug.Log("your mana is " + m_playerMana);
        }
    }

   
}
