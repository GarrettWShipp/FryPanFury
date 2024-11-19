using SuperPupSystems.Helper;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public TMP_Text healthText;
    public Slider healthSlider;

    private Health m_health;
    public GameObject defending;
    public GameObject attacking;
    public GameObject spell;
    public TMP_Text damageNum;
    public int defense;
    public int bonusDefense;
    public GameObject defenseIcon;
    public TMP_Text defenseText;

    public int damage;
    private int m_ogDamage;
    private int m_buffValue = 2;
    private int m_debuffValue = 2;

    private int m_tempAttack;
    private int m_tempDefense;

    private PlayerManager m_playerManager;

    [HideInInspector] public EnemyAttackPattern enemyMovePattern;
    [HideInInspector] public int counter = 0;
    [HideInInspector] public int maxCounter;

    public int debuffCounter;
    public int buffCounter;

    public bool isDebuffed = false;
    public bool isBuffed = false;
    public GameObject BuffGFX;
    public GameObject DebuffGFX;

    public float flashTime;
    Color origionalColor;
    public Image Image;

    private Animator m_anim;
    public bool enemyAnimIsDone = false;

    [HideInInspector] public InfoType infoType;
    [HideInInspector] public SimpleCardScript[] movelist;

    [HideInInspector] public SimpleCardScript nextMove;

    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        m_health = this.GetComponent<Health>();
        enemyMovePattern = this.GetComponent<EnemyAttackPattern>();
        origionalColor = Image.color;
        m_ogDamage = damage;
        movelist = enemyMovePattern.EnemyCards;

        nextMove = movelist[0];
    }

    // Update is called once per frame
    void Update()
    {
        damageNum.text = damage.ToString();
        nextMove = movelist[0];
        
        healthSlider.maxValue = m_health.maxHealth;

        healthText.text = (int)m_health.currentHealth + "/" + (int)m_health.maxHealth;

        healthSlider.value = m_health.currentHealth;
        //healthText.text = m_health.currentHealth.ToString();

        if (defense > 0)
        {
            defenseIcon.SetActive(true);
            defenseText.text = defense.ToString();
        }
        else
        {
            defenseIcon.SetActive(false);
        }

        
        infoType = movelist[0].infoType;
        
        
        if (isBuffed)
        {
            BuffGFX.SetActive(true);
            damage = damage * m_buffValue;
            
        }
        else
        {
            BuffGFX.SetActive(false);
            damage = m_ogDamage;
        }

        if (isDebuffed)
        {
            DebuffGFX.SetActive(true);
            damage = damage / m_debuffValue;
            
        }
        else
        {
            DebuffGFX.SetActive(false);
            damage = m_ogDamage;
        }
        
    }

    public void Attack()
    {
        //Deal damage
        Debug.Log("Attack");
        m_anim.SetTrigger("Attack");

        if(m_playerManager.defense > 0)
        {
            m_tempAttack = damage - m_playerManager.defense;
            m_tempDefense = m_playerManager.defense - damage;

            damage = m_tempAttack;
            m_playerManager.defense = m_tempDefense;
        }
        if(damage < 0)
        { 
            damage = 0; 
        }
        if (m_playerManager.defense <= 0)
        {
            m_playerManager.defense = 0;
            if(isDebuffed)
            {
                m_playerManager.GetComponent<Health>().Damage(damage);
            }
            if (isBuffed)
            {
                m_playerManager.GetComponent<Health>().Damage(damage);
            }
            if (!isDebuffed && !isBuffed)
                m_playerManager.GetComponent<Health>().Damage(damage);
        }
        enemyAnimIsDone = false;
    }
    public void Poison()
    {
        m_playerManager.poisonCounter += 3;
        m_playerManager.isPoisoned = true;
        Debug.Log("Poisoned");
    }
    public void Defend()
    {
        //Give defense
        Debug.Log("Defend");
        defense += bonusDefense;
    }

    public void Debuff()
    {
        //Makes m_playerManager Deal less damage
        Debug.Log("Debuff");
        m_anim.SetTrigger("Spell");
        m_playerManager.isDebuffed = true;
        m_playerManager.debuffCounter += 3;
    }
    public void Buff()
    {
        //Makes enemy do more Damage
        Debug.Log("Buff");
        m_anim.SetTrigger("Spell");
        isBuffed = true;
        buffCounter += 3;
    }

    public void FlashRed()
    {
        Image.color = Color.red;
        Invoke("ResetColor", flashTime);
    }
    public void ResetColor()
    {
        Image.color = origionalColor;
    }

    public void AnimTrigger()
    {
        enemyAnimIsDone = true;
    }

    public SimpleCardScript[] Shift(SimpleCardScript[] myArray)
    {
        Debug.Log("Shift" + myArray[0]);
        SimpleCardScript[] tArray = new SimpleCardScript[myArray.Length];
        for (int i = 0; i < myArray.Length; i++)
        {
            if (i < myArray.Length - 1)
                tArray[i] = myArray[i + 1];
            else
                tArray[i] = myArray[0];
        }
        Debug.Log("done shift" + tArray[0]);
        return tArray;
    }
}
