using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CardManager : MonoBehaviour
{
    
    public List<GameObject> Deck;
    public List<GameObject> Hand;
    public List<GameObject> Discard;
    // Start is called before the first frame update
    void Start()
    {
        if (Deck == null)
            Debug.LogError("Deck is empty put a gameObject into the deck list");

    }

    private void Update()
    {
        for (int i = 0; i < Hand.Count; i++)
        {

        }
    }

    //Puts a card from deck to hand
    public void DrawCard()
    {
        if(Deck.Count == 0)
        {
            ReshuffleCards();
        }
        GameObject card = Deck[0];
        Deck.RemoveAt(0);
        Hand.Add(card);
        card.SetActive(true);
        
    }

    public void UseCard()
    {
        GameObject card = Hand[0];
        Hand.RemoveAt(0);
        Discard.Add(card);
        card.SetActive(false);
    }

    public void ReshuffleCards()
    {
        while(Discard.Count != 0)
        {
            GameObject card = Discard[0];
            Discard.RemoveAt(0);
            Deck.Add(card);
        }
    }

}