using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using SuperPupSystems.Helper;

public class PlayerManager : MonoBehaviour
{
    public TMP_Text manaLeftText;
    public TMP_Text manaTotalText;
    public Slider manaSlider;

    public TMP_Text healthLeftText;
    public TMP_Text healthTotalText;
    public Slider healthSlider;

    public int defense;
    public GameObject defenseIcon;
    public TMP_Text defenseText;

    public Health playerHealth;

    //Player stats
    public int curMana;
    public int mana;

    public int totalHandSize = 5;
    // Start is called before the first frame update
    void Start()
    {
        
        curMana = mana;
    }

    // Update is called once per frame
    void Update()
    {
        manaSlider.maxValue = mana;
        manaTotalText.text = mana.ToString();

        manaSlider.value = curMana;
        manaLeftText.text = curMana.ToString();

        healthSlider.maxValue = playerHealth.maxHealth;
        healthTotalText.text = playerHealth.maxHealth.ToString();

        healthSlider.value = playerHealth.currentHealth;
        healthLeftText.text = playerHealth.currentHealth.ToString();

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
