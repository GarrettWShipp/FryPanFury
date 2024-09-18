using UnityEngine.UI;
using SuperPupSystems.Helper;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public TMP_Text healthLeftText;
    public TMP_Text healthTotalText;
    public Slider healthSlider;

    public Health enemyHealth;
    public int defense;
    public GameObject defenseIcon;
    public TMP_Text defenseText;

    private GameObject m_player;
    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.maxValue = enemyHealth.maxHealth;
        healthTotalText.text = enemyHealth.maxHealth.ToString();

        healthSlider.value = enemyHealth.currentHealth;
        healthLeftText.text = enemyHealth.currentHealth.ToString();

        if(defense > 0)
        {
            defenseIcon.SetActive(true);
            defenseText.text = defense.ToString();

        }
        else
        {
            defenseIcon.SetActive(false);
        }
    }
}
