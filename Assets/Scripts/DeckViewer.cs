using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckViewer : MonoBehaviour
{
    public GameManager gameManager;
    public int numOfCards;
    public GameObject rowPrefab;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ViewCards()
    {
        for (int i = 0; i <= gameManager.cards.Count / numOfCards; i++)
        {
            GameObject row = Instantiate(rowPrefab, this.transform);
            row.name = "Row " + i.ToString();
            if (i == 0)
            {
                for (int j = 0; j <= numOfCards - 1; j++)
                {
                    Instantiate(gameManager.cards[i * numOfCards + j], row.transform);
                }
            }
            else
            {
                for (int j = 0; j <= numOfCards - 1; j++)
                {
                    if(j < gameManager.cards.Count)
                        Instantiate(gameManager.cards[i * numOfCards + j], row.transform);
                }
            }
        }
    }
}
