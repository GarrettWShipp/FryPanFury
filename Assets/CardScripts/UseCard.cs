using SuperPupSystems.Helper;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UseCard : MonoBehaviour
{
    public SimpleCardScript cardScript;
    public PlayerManager player;
    public Health targetHealth;

    private int cardMana;
    private int playerMana;

    private int cardAttack;
    private int cardDefense;

    // Start is called before the first frame update
    void Start()
    {
        cardMana = cardScript.manaCost;
        playerMana = player.curMana;

        cardAttack = cardScript.attack;
        cardDefense = cardScript.Defensive;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryToPlayCard()
    {
        Debug.Log("Tried to play card");
        if (playerMana >= cardMana)
        {
            player.curMana -= cardMana;

            player.defense += cardDefense;

            targetHealth.Damage(cardAttack);

            Debug.Log("Played card");

            this.gameObject.SetActive(false);
        }

        if (playerMana < cardMana)
        {
            Debug.Log("You don't have the mana to play this card");
        }
    }
}
