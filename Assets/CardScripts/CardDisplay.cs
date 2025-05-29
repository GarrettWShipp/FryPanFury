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

    public GameObject rage;
    public GameObject dmgDebuff;
    public GameObject defDebuff;
    public GameObject dmgBuff;
    public GameObject defBuff;
    public GameObject poisonous;
    public GameObject bleed;
    public GameObject fire;

    public TMP_Text manaText;
    public TMP_Text attackText;
    public TMP_Text defenseText;

    private PlayerManager m_playerManager;
    private PlayCard m_card;
    // Start is called before the first frame update
    void Start()
    {
        m_playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        m_card = GetComponent<PlayCard>();
        nameText.text = card.name;

        cardArt.sprite = card.cardImage;

        manaText.text = card.manaCost.ToString();
        defenseText.text = card.Defensive.ToString();
    }

    private void Update()
    {
        if (m_card != null && gameObject.GetComponent<Attack>() != null)
            attackText.text = gameObject.GetComponent<Attack>().cardAttack.ToString();

        if(card.infoType.rage == true)
        {
            rage.SetActive(true);
        }
        else
            rage.SetActive(false);
        if (card.infoType.dmgDebuff == true)
        {
            dmgDebuff.SetActive(true);
        }
        else
            dmgDebuff.SetActive(false);
        if (card.infoType.defDebuff == true)
        {
            defDebuff.SetActive(true);
        }
        else
            defDebuff.SetActive(false);
        if (card.infoType.dmgBuff == true)
        {
            dmgBuff.SetActive(true);
        }
        else
            dmgBuff.SetActive(false);
        if (card.infoType.defBuff == true)
        {
            defBuff.SetActive(true);
        }
        else
            defBuff.SetActive(false);
        if (card.infoType.poisonous == true)
        {
            poisonous.SetActive(true);
        }
        else
            poisonous.SetActive(false);
        if (card.infoType.bleed == true)
        {
            bleed.SetActive(true);
        }
        else
            bleed.SetActive(false);
        if (card.infoType.fire == true)
        {
            fire.SetActive(true);
        }
        else
            fire.SetActive(false);
    }
}
