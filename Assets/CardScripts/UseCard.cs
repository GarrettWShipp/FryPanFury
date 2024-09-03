using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCard : MonoBehaviour
{
    public SimpleCardScript cardScript;
    public PlayerManager player;
    public GameObject target;

    private int cardMana;
    private int playerMana;

    // Start is called before the first frame update
    void Start()
    {
        cardMana = cardScript.manaCost;
        playerMana = player.curMana;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryToPlayCard()
    {
        if (playerMana >= cardMana)
        {
            player.curMana -= cardMana;

            
        }

        if (playerMana <= cardMana)
        {
            Debug.Log("You don't have the mana to play this card");
        }
    }
}
