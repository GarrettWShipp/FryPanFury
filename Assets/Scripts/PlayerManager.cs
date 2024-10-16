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
    // Start is called before the first frame update
    void Awake()
    {
        
        curMana = mana;
        m_health = this.GetComponent<Health>();
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
    }
}
