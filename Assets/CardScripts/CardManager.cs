using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class CardManager : MonoBehaviour
{
    //private AudioManager m_audio;
    public List<GameObject> Deck;
    public List<GameObject> Hand;
    public List<GameObject> Discard;
    public Animator anim;
    public bool animIsDone = false;
    public int m_drawCount;
    public TMP_Text deckText;
    public TMP_Text discardText;
    private int m_ranInt;
    public GameObject cardBar;

    // Start is called before the first frame update

    private void Awake()
    {
        cardBar = GameObject.FindGameObjectWithTag("Hand");
    }
    void Start()
    {
        if (Deck == null)
            Debug.LogError("Deck is empty put a gameObject into the deck list");

    }

    private void Update()
    {
        
        deckText.text = Deck.Count.ToString();
        discardText.text = Discard.Count.ToString();
        if (animIsDone)
        {
            GameObject card = Deck[m_ranInt];
            Hand.Add(card);
            card.SetActive(true);
            Deck.RemoveAt(m_ranInt);
            animIsDone = false;
            //AudioManager.instance.PlaySFX("Draw");
            m_drawCount -= 1;
        }
        if(m_drawCount != 0)
        {
            DrawCard(m_drawCount);
        }

    }

    public void AddCard()
    {

    }

    //Puts a card from deck to hand
    public void DrawCard(int _drawAmount)
    {
        m_ranInt = Random.Range(0, Deck.Count);
        m_drawCount = _drawAmount;
        if(Deck.Count == 0)
        {
            ReshuffleCards();
        }
        if(_drawAmount - 1 != 0)
        {
            anim.SetTrigger("Draw");
        }
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