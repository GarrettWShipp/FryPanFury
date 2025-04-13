using SuperPupSystems.Helper;
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

    public bool onFire = false;
    public int fireCounter;
    public int fireDmg = 3;

    public bool isPoisoned = false;
    public int poisonCounter;
    public int poisonDmg = 2;

    public int damage;
    private int m_ogDamage;
    private int m_buffValue = 2;
    private int m_debuffValue = 2;

    private int m_tempAttack;
    private int m_tempDefense;

    private PlayerManager m_playerManager;
    public GameObject m_combatStats;

    [HideInInspector] public EnemyAttackPattern enemyMovePattern;
    [HideInInspector] public int counter = 0;
    [HideInInspector] public int maxCounter;

    public int dmgDebuffCounter;
    public int dmgBuffCounter;
    public int defDebuffCounter;
    public int defBuffCounter;

    public bool dmgIsDebuffed = false;
    public bool dmgIsBuffed = false;
    public GameObject dmgBuffGFX;
    public GameObject dmgDebuffGFX;

    public bool defIsDebuffed = false;
    public bool defIsBuffed = false;
    public GameObject defBuffGFX;
    public GameObject defDebuffGFX;

    public float flashTime;
    Color origionalColor;
    public Image Image;

    private Animator m_anim;
    public bool enemyAnimIsDone = false;

    [HideInInspector] public InfoType infoType;
    [HideInInspector] public SimpleCardScript[] movelist;

    [HideInInspector] public SimpleCardScript nextMove;

    public Vector2Int awardCoinsRange;
    private int m_coins;

    // Start is called before the first frame update
    private void Awake()
    {
        m_combatStats = GameObject.Find("CombatStats");
    }
    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        m_combatStats.SetActive(false);
        m_health = this.GetComponent<Health>();
        enemyMovePattern = this.GetComponent<EnemyAttackPattern>();
        origionalColor = Image.color;
        m_ogDamage = damage;
        movelist = enemyMovePattern.EnemyCards;
        m_coins = Random.Range(awardCoinsRange.x, awardCoinsRange.y);
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
        
        
        if (dmgIsBuffed)
        {
            dmgBuffGFX.SetActive(true);
            damage = damage * m_buffValue;
            
        }
        else
        {
            dmgBuffGFX.SetActive(false);
            damage = m_ogDamage;
        }

        if (dmgIsDebuffed)
        {
            dmgDebuffGFX.SetActive(true);
            damage = damage / m_debuffValue;
            
        }
        else
        {
            dmgDebuffGFX.SetActive(false);
            damage = m_ogDamage;
        }
        if (defIsBuffed)
        {
            defBuffGFX.SetActive(true);
            damage = damage * m_buffValue;

        }
        else
        {
            defBuffGFX.SetActive(false);
            damage = m_ogDamage;
        }

        if (defIsDebuffed)
        {
            defDebuffGFX.SetActive(true);
            damage = damage / m_debuffValue;

        }
        else
        {
            defDebuffGFX.SetActive(false);
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
            m_playerManager.GetComponent<Health>().Damage(damage);
            /*
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
            */
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

    public void DefDebuff()
    {
        //Makes m_playerManager Deal less damage
        Debug.Log("Debuff");
        m_anim.SetTrigger("Spell");
        m_playerManager.defIsDebuffed = true;
        m_playerManager.defDebuffCounter += 3;
    }
    public void DefBuff()
    {
        //Makes enemy do more Damage
        Debug.Log("Buff");
        m_anim.SetTrigger("Spell");
        defIsBuffed = true;
        defBuffCounter += 3;
    }
    public void DmgDebuff()
    {
        //Makes m_playerManager Deal less damage
        Debug.Log("Debuff");
        m_anim.SetTrigger("Spell");
        m_playerManager.dmgIsDebuffed = true;
        m_playerManager.dmgDebuffCounter += 3;
    }
    public void DmgBuff()
    {
        //Makes enemy do more Damage
        Debug.Log("Buff");
        m_anim.SetTrigger("Spell");
        dmgIsBuffed = true;
        dmgBuffCounter += 3;
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
    public void addCoins()
    {
        m_combatStats.GetComponent<CombatStatMenu>().totalCoins += m_coins;
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
