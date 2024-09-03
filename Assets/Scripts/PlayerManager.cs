using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    //Player stats
    public int curHealth;
    public int health;

    public int curMana;
    public int mana;

    public int defense;

    public int handSize;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = health;
        curMana = mana;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
