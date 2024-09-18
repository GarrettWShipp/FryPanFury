using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CardManager : MonoBehaviour
{
    //public GameObject cardBar;
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

    }

    public void AddCard()
    {

    }

    //Puts a card from deck to hand
    public void DrawCard()
    {
        if(Deck.Count == 0)
        {
            ReshuffleCards();
        }
        GameObject card = Deck[0];
        Hand.Add(card);
        card.SetActive(true);
        Deck.RemoveAt(0);
    }

    public void UseCard(GameObject card)
    {
        card.SetActive(false);
        Discard.Add(card);
        Hand.Remove(card);
    }

    public void ReshuffleCards()
    {
        while(Discard.Count != 0)
        {
            GameObject card = Discard[0];
            Deck.Add(card);
            Discard.RemoveAt(0);

        }
    }
    
    public void DiscardAll()
    {
        while(Hand.Count != 0)
        {
            GameObject card = Hand[0];
            card.SetActive(false);
            Discard.Add(card);
            Hand.RemoveAt(0);
        }
    }
}