using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatStatMenu : MonoBehaviour
{
    public CombatManager combatManager;
    public GameManager gameManager;
    private int m_curScene;
    public GameObject nextButton;
    public GameObject retry;
    public TMP_Text coinText;
    public TMP_Text combatText;
    public int totalCoins;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManger").GetComponent<GameManager>();
        combatManager = GameObject.Find("CombatManager").GetComponent<CombatManager>();
    }
    private void Update()
    {
        
        m_curScene = SceneManager.GetActiveScene().buildIndex;
        if (combatManager.combatIsDone)
        {
            nextButton.SetActive(true);
            retry.SetActive(false);
            coinText.text = "Total coins: " + totalCoins;
            combatText.text = "You Won Congrats";

        }
        else
        {
            retry.SetActive(true);
            nextButton.SetActive(false);
            combatText.text = "You lose try again";
        }
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadNext()
    {
        gameManager.coins += totalCoins;
        gameManager.numberOfFights++;
        if(gameManager.GetComponent<GameSettings>().shortRest)
        {
            SceneManager.LoadScene("ShortRest");
        }
        if (SceneManager.GetSceneByBuildIndex(m_curScene + 1) == null)
            SceneManager.LoadScene("MainMenu");
        else
            SceneManager.LoadScene(m_curScene + 1);
    }

}
