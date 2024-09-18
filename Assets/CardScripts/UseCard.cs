using SuperPupSystems.Helper;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UseCard : MonoBehaviour
{
    public SimpleCardScript cardScript;
    public PlayerManager player;
    public Health targetHealth;
    public EnemyManager enemyManager;

    public Button card;
    public bool clicked = false;

    public CardManager cardManager;

    private int m_cardMana;
    private int m_playerMana;

    private int m_cardAttack;
    private int m_cardDefense;

    public Canvas parentCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 pos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform, Input.mousePosition,
            parentCanvas.worldCamera,
            out pos);

        m_cardMana = cardScript.manaCost;

        m_cardAttack = cardScript.attack;
        m_cardDefense = cardScript.Defensive;
    }

    // Update is called once per frame
    void Update()
    {
        if(clicked == true)
        {
            FollowMouse();
        }
        bool isPointOVerThis = RaycastUtilities.PointerIsOverUI(Input.mousePosition, this.gameObject);

        if (isPointOVerThis)
        {
            Debug.Log("Pointer is OVer disabled UI");
        }
            m_playerMana = player.curMana;
    }

    public void TryToPlayCard()
    {
        Debug.Log("Tried to play card");
        if (m_playerMana >= m_cardMana)
        {
            player.curMana -= m_cardMana;

            player.defense += m_cardDefense;
            
            if(enemyManager.defense <= 0)
                targetHealth.Damage(m_cardAttack);

            if(enemyManager.defense > 0)
            {
                targetHealth.Damage(m_cardAttack - enemyManager.defense);
                enemyManager.defense -= m_cardAttack;
            }


            Debug.Log("Played card");

            cardManager.UseCard(gameObject);

            RectTransform picture = GetComponent<RectTransform>();
            picture.anchoredPosition = new Vector2(807f, -100);
        }

        if (m_playerMana < m_cardMana)
        {
            Debug.Log("You don't have the mana to play this card");
            Debug.Log("Card mana is " + m_cardMana);
            Debug.Log("your mana is " + m_playerMana);
        }
    }

    public void FollowMouse()
    {
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            Input.mousePosition, parentCanvas.worldCamera,
            out movePos);

        transform.position = parentCanvas.transform.TransformPoint(movePos);
    }

    public void clickOn()
    {
        clicked = true;
    }
    private void OnMouseOver()
    {
        
    }
}

public static class RaycastUtilities
{
    public static bool PointerIsOverUI(Vector2 screenPos, GameObject GO)
    {
        var hitObject = UIRaycast(ScreenPosToPointerData(screenPos));
        return hitObject != null && hitObject.layer == LayerMask.NameToLayer("UI") && hitObject == GO;
    }

    public static GameObject UIRaycast(PointerEventData pointerData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
        Debug.Log(results[0].gameObject.name + "Was raycast hit...");
        return results.Count < 1 ? null : results[0].gameObject;
    }

    static PointerEventData ScreenPosToPointerData(Vector2 screenPos)
       => new(EventSystem.current) { position = screenPos };
}