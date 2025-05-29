using SuperPupSystems.Helper;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    //private AudioManager m_audio;
    public List<GameObject> Deck;
    public List<GameObject> Hand;
    public List<GameObject> Discard;
    public List<GameObject> AllCards;
    public Animator anim;
    public bool animIsDone = false;
    public int drawCount;
    public TMP_Text deckText;
    public TMP_Text discardText;
    private int m_ranInt;
    public GameObject cardBar;
    public Button NextButton;
    private GameManager m_gameManager;

    // Start is called before the first frame update

    private void Awake()
    {
        cardBar = GameObject.FindGameObjectWithTag("Hand");
        m_gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        if (Deck == null)
            Debug.LogError("Deck is empty put a gameObject into the deck list");

        Deck = m_gameManager.cards;

    }

    private void Update()
    {
        
        deckText.text = Deck.Count.ToString();
        discardText.text = Discard.Count.ToString();
        if (animIsDone)
        {
            GameObject card = Deck[m_ranInt];
            Hand.Add(card);
            Deck.RemoveAt(m_ranInt);
            Instantiate(card, cardBar.transform);
            animIsDone = false;
            //AudioManager.instance.PlaySFX("Draw");
            drawCount -= 1;
        }
        if(drawCount != 0)
        {
            DrawCard(drawCount);
        }
        if(drawCount == 0)
        {
            NextButton.interactable = true;
            for(int i = 0; i < Hand.Count; i++)
            {
                if (Hand[i] == null)
                {
                    return;
                }
                if (Hand[i].GetComponent<PlayCard>().beingDragged == false)
                {
                    Hand[i].GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
                else
                    Hand[i].GetComponent<CanvasGroup>().blocksRaycasts = false;

            }
        }
        else
        {
            NextButton.interactable = false;
            for (int i = 0; i < Hand.Count; i++)
            {
                if (Hand[i] == null)
                {
                    return;
                }
                Hand[i].GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }

    }

    public void AddCard()
    {

    }

    //Puts a card from deck to hand
    public void DrawCard(int _drawAmount)
    {
        m_ranInt = Random.Range(0, Deck.Count);
        drawCount = _drawAmount;
        if(Deck.Count == 0)
        {
            ReshuffleCards();
        }
        if(_drawAmount - 1 != 0)
        {
            anim.SetTrigger("Draw");
        }
    }

    public void discardCard(GameObject prefab)
    {
        int count = 0;
        if (count == 0)
        {
            for (int i = 0; i < AllCards.Count; i++)
            {
                if (AllCards[i].GetComponent<PlayCard>().cardScript == prefab.GetComponent<PlayCard>().cardScript)
                {
                    Discard.Add(AllCards[i]);
                    break;
                }
            }
            for (int i = 0; i < Hand.Count; i++)
            {
                if (Hand[i].GetComponent<PlayCard>().cardScript == prefab.GetComponent<PlayCard>().cardScript)
                {
                    Hand.Remove(Hand[i]);

                }
            }
            
        }
        
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
            for (int i = 0; i < AllCards.Count; i++)
            {
                if (AllCards[i].GetComponent<PlayCard>().cardScript == card.GetComponent<PlayCard>().cardScript)
                {
                    Discard.Add(AllCards[i]);
                }
            }
            Hand.RemoveAt(0);
        }
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        for(int i = 0;i < cards.Length;i++)
        {
            Destroy(cards[i]);
        }
        
    }


}