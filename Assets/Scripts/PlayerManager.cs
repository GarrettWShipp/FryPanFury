using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    //Player stats
    public int curMana;
    public int mana;

    public int defense;

    public int deckSize;
    // Start is called before the first frame update
    void Start()
    {
        curMana = mana;
    }

    // Update is called once per frame
    void Update()
    {
        if (curMana == 0)
        {
            Debug.Log("Out of mana");
        }
    }
}
