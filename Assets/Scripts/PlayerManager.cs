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

    //Player stats
    public int curMana;
    public int mana;

    public int totalHandSize = 5;


    public int debuffCounter;
    public int buffCounter;

    public bool isDebuffed = false;
    public bool isBuffed = false;

    public int buffvalue = 2;
    public int debuffvalue = 2;

    public GameObject BuffGFX;
    public GameObject DebuffGFX;

    public float flashTime;
    Color origionalColor;
    public Image Image;
    // Start is called before the first frame update
    void Awake()
    {

        curMana = mana;
        m_health = this.GetComponent<Health>();
        origionalColor = Image.color;
    }

    // Update is called once per frame
    void Update()
    {
        manaSlider.maxValue = mana;
        manaText.text = (int)curMana + "/" + (int)mana;

        manaSlider.value = curMana;

        healthSlider.maxValue = m_health.maxHealth;
        healthSlider.value = m_health.currentHealth;
        healthText.text = (int)m_health.currentHealth + "/" + (int)m_health.maxHealth;
        if(debuffCounter == 0)
        {
            isDebuffed = false;
        }
        if (buffCounter == 0)
        {
            isBuffed = false;
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
        if (isBuffed)
        {
            BuffGFX.SetActive(true);
        }
        else
            BuffGFX.SetActive(false);
        if (isDebuffed)
        {
            DebuffGFX.SetActive(true);
        }
        else
            DebuffGFX.SetActive(false);

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
