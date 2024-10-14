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
    public TMP_Text damageNum;
    public int defense;
    public int bonusDefense;
    public GameObject defenseIcon;
    public TMP_Text defenseText;

    public int damage;

    private GameObject m_player;

    private EnemyAttackPattern m_enemyAttackPattern;
    [HideInInspector] public string currentAttack;
    [HideInInspector] public int counter = 0;
    [HideInInspector] public int maxCounter;
    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindWithTag("Player");
        m_health = this.GetComponent<Health>();
        m_enemyAttackPattern = this.GetComponent<EnemyAttackPattern>();
        maxCounter = m_enemyAttackPattern.attackPattern.Length;

    }

    // Update is called once per frame
    void Update()
    {
        
        damageNum.text = damage.ToString();

        healthSlider.maxValue = m_health.maxHealth;

        healthSlider.value = m_health.currentHealth;
        //healthText.text = m_health.currentHealth.ToString();

        if(defense > 0)
        {
            defenseIcon.SetActive(true);
            defenseText.text = defense.ToString();

        }
        else
        {
            defenseIcon.SetActive(false);
        }

        if(counter + 1 > maxCounter)
        {
            currentAttack = m_enemyAttackPattern.attackPattern[0];
        }
        else
        {
            currentAttack = m_enemyAttackPattern.attackPattern[counter];
        }
    }

    public void Attack()
    {
        //Deal damage
        Debug.Log("Attack");
        int dmg = damage - defense;
        if (dmg > 0)
        {
            m_player.GetComponent<Health>().Damage(dmg);
            m_player.GetComponent<PlayerManager>().defense -= damage;
        }
    }

    public void Defend()
    {
        //Give defense
        Debug.Log("Defend");
        defense += bonusDefense;
    }

    public void Debuff()
    {
        //Makes player Deal less damage
        Debug.Log("Debuff");
    }
    public void Buff()
    {
        //Makes enemy do more Damage
        Debug.Log("Buff");
    }
    public void Heal()
    {
        //Heal lowest Enemy
        Debug.Log("Heal");
    }
}
