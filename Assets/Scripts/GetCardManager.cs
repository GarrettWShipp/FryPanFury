using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCardManager : MonoBehaviour
{
    private GameObject m_cardManager;
    // Start is called before the first frame update
    void Start()
    {
        m_cardManager = GameObject.FindWithTag("CardManager");
    }

    public void AnimTrigger()
    {
        m_cardManager.GetComponent<CardManager>().animIsDone = true;
        AudioManager.instance.PlaySFX("Draw");
    }
}
