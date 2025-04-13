using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using SuperPupSystems.Helper;

public class PlayerManager : MonoBehaviour
{
    public TMP_Text manaText;
    public Slider manaSlider;

    public TMP_Text healthText;
    public Slider healthSlider;

    public int defense;
    public GameObject defenseIcon;
    public TMP_Text defenseText;

    private Health m_health;

    private GameManager m_gameManager;

    //Player stats
    public int curMana;
    public int mana;

    public bool isRaging;
    public int rageCounter;
    public GameObject rageMeter;

    public int totalHandSize = 5;

    public int bonusDmg;

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


    public int dmgBuffValue = 2;
    public int dmgDebuffValue = 2;

    public int defBuffValue = 2;
    public int defDebuffValue = 2;

    public int poisonDamage = 2;
    public int poisonCounter;
    public bool isPoisoned = false;
    public GameObject PoisonGFX;

    public bool onFire = false;
    public int fireCounter;
    public int fireDmg = 3;

    public int coins = 0;

    public GameObject invetory;

    public float flashTime;
    Color origionalColor;
    public Image Image;
    public KeyCode invetoryKey;
    private bool m_invetoryIsOpen = false;
    // Start is called before the first frame update
    void Awake()
    {

        curMana = mana;
        m_health = this.GetComponent<Health>();
        origionalColor = Image.color;
        m_gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    public void Start()
    {
        m_health.currentHealth = m_gameManager.health;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(invetoryKey))
        {
            invetory.SetActive(true);
        }
        if (Input.GetKeyUp(invetoryKey))
        {
            invetory.SetActive(false);
        }

            
        rageMeter.GetComponent<RageMeter>().curRage = rageCounter;
        manaSlider.maxValue = mana;
        manaText.text = (int)curMana + "/" + (int)mana;

        manaSlider.value = curMana;

        healthSlider.maxValue = m_health.maxHealth;
        healthSlider.value = m_health.currentHealth;
        healthText.text = (int)m_health.currentHealth + "/" + (int)m_health.maxHealth;
        if(dmgDebuffCounter == 0)
        {
            dmgIsDebuffed = false;
        }
        if (dmgBuffCounter == 0)
        {
            dmgIsBuffed = false;
        }

        if (defDebuffCounter == 0)
        {
            defIsDebuffed = false;
        }
        if (defBuffCounter == 0)
        {
            defIsBuffed = false;
        }
        if (poisonCounter == 0)
        {
            isPoisoned = false;
        }
        if (defense > 0)
        {
            defenseIcon.SetActive(true);
            defenseText.text = defense.ToString();

        }
        else
        {
            defenseIcon.SetActive(false);
        }

        if (curMana == 0)
        {
            Debug.Log("Out of mana");
        }
        if (dmgIsBuffed)
        {
            dmgBuffGFX.SetActive(true);
        }
        else
            dmgBuffGFX.SetActive(false);
        if (dmgIsDebuffed)
        {
            dmgDebuffGFX.SetActive(true);
        }
        else
            dmgDebuffGFX.SetActive(false);

        if (defIsBuffed)
        {
            defBuffGFX.SetActive(true);
        }
        else
            defBuffGFX.SetActive(false);
        if (defIsDebuffed)
        {
            defDebuffGFX.SetActive(true);
        }
        else
            defDebuffGFX.SetActive(false);

        if (isPoisoned)
        {
            PoisonGFX.SetActive(true);
        }
        else
            PoisonGFX.SetActive(false);

        
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


}
