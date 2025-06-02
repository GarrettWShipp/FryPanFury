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
    public List<GameObject> deck;
    public List<GameObject> hand;
    public List<GameObject> discard;
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
        if (deck == null)
            Debug.LogError("Deck is empty put a gameObject into the deck list");
        
    }

    private void Update()
    {
        deckText.text = deck.Count.ToString();
        discardText.text = discard.Count.ToString();

        if (drawCount != 0)
        {
            DrawCard(drawCount);
            NextButton.interactable = false;
            for (int i = 0; i < hand.Count; i++)
            {
                if (hand[i] == null)
                {
                    return;
                }
                hand[i].GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }
        if(drawCount == 0)
        {
            NextButton.interactable = true;
            for(int i = 0; i < hand.Count; i++)
            {
                if (hand[i] == null)
                {
                    return;
                }
                hand[i].GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
        }

    }

    public void AddCard()
    {

    }

    //Puts a card from deck to hand
    public void DrawCard(int _drawAmount)
    {
        m_ranInt = Random.Range(0, deck.Count);
        drawCount = _drawAmount;
        if (deck.Count == 0)
        {
            ReshuffleCards();
        }
        if (_drawAmount - 1 != 0)
        {
            anim.SetTrigger("Draw");
        }
        if (animIsDone)
        {
            GameObject card = deck[m_ranInt];
            card.SetActive(true);
            hand.Add(card);
            deck.RemoveAt(m_ranInt);
            animIsDone = false;
            //AudioManager.instance.PlaySFX("Draw");
            drawCount -= 1;
        }
    }


    public void ReshuffleCards()
    {
        while(discard.Count != 0)
        {
            int randNum = Random.Range(0, discard.Count - 1);
            GameObject card = discard[randNum];
            deck.Add(card);
            discard.RemoveAt(randNum);

        }
    }
    
    public void DiscardAll()
    {
        while (hand.Count != 0)
        {
            hand[0].SetActive(false);
            discard.Add(hand[0]);
            hand.RemoveAt(0);
        }
        
    }


}