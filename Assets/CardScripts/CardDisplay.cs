using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public SimpleCardScript card;
    public Image cardArt;

    public TMP_Text nameText;
    public TMP_Text descriptionText;

    public TMP_Text manaText;
    public TMP_Text attackText;
    public TMP_Text defenseText;

    private PlayerManager m_playerManager;
    private UseCard m_card;
    // Start is called before the first frame update
    void Start()
    {
        m_playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        m_card = GetComponent<UseCard>();
        nameText.text = card.name;
        descriptionText.text = card.description;

        cardArt.sprite = card.cardImage;

        manaText.text = card.manaCost.ToString();
        defenseText.text = card.Defensive.ToString();
    }

    private void Update()
    {
            attackText.text = m_card.cardAttack.ToString();
    }
}
