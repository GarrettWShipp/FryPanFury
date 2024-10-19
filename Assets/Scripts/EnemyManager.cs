using UnityEngine.UI;
using SuperPupSystems.Helper;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    private int m_buffDamage;
    private int m_debuffDamage;

    private int m_tempAttack;
    private int m_tempDefense;

    private PlayerManager m_playerManager;

    private EnemyAttackPattern m_enemyAttackPattern;
    [HideInInspector] public string nextAttack;
    [HideInInspector] public string currentAttack;
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

    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        m_health = this.GetComponent<Health>();
        m_enemyAttackPattern = this.GetComponent<EnemyAttackPattern>();
        maxCounter = m_enemyAttackPattern.attackPattern.Length;
        origionalColor = Image.color;
        m_buffDamage = damage * 2;
        m_debuffDamage = damage / 2;
        m_ogDamage = damage;

    }

    // Update is called once per frame
    void Update()
    {
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

        if (counter + 1 > maxCounter)
        {
            nextAttack = m_enemyAttackPattern.attackPattern[0];
            currentAttack = m_enemyAttackPattern.attackPattern[maxCounter - 1];
        }
        else
        {
            nextAttack = m_enemyAttackPattern.attackPattern[counter];
        }
        if (isBuffed)
        {
            BuffGFX.SetActive(true);
            damage = m_buffDamage;
            damageNum.text = m_buffDamage.ToString();
        }
        if (isDebuffed)
        {
            DebuffGFX.SetActive(true);
            damage = m_debuffDamage;
            damageNum.text = m_debuffDamage.ToString();
        }
        if (!isBuffed && !isDebuffed)
        {
            DebuffGFX.SetActive(false);
            BuffGFX.SetActive(false);
            damage = m_ogDamage;
            damageNum.text = damage.ToString();
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
        m_playerManager.isDebuffed = true;
        m_playerManager.debuffCounter += 3;
    }
    public void Buff()
    {
        //Makes enemy do more Damage
        Debug.Log("Buff");
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
}
