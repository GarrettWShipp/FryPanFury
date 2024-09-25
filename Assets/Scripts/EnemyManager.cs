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

    private Health m_health;
    public GameObject defending;
    public GameObject attacking;
    public TMP_Text damageNum;
    public int defense;
    public GameObject defenseIcon;
    public TMP_Text defenseText;

    public int damage;

    private GameObject m_player;
    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindWithTag("Player");
        m_health = this.GetComponent<Health>();

    }

    // Update is called once per frame
    void Update()
    {
        damageNum.text = damage.ToString();

        healthSlider.maxValue = m_health.maxHealth;
        healthTotalText.text = m_health.maxHealth.ToString();

        healthSlider.value = m_health.currentHealth;
        healthLeftText.text = m_health.currentHealth.ToString();

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
