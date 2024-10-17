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
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.name;
        descriptionText.text = card.description;

        cardArt.sprite = card.cardImage;

        manaText.text = card.manaCost.ToString();
        attackText.text = card.attack.ToString();
        defenseText.text = card.Defensive.ToString();
    }

    private void Update()
    {
        attackText.text = card.attack.ToString();
        defenseText.text = card.Defensive.ToString();
    }
}
