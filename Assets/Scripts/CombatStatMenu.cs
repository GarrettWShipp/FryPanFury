using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatStatMenu : MonoBehaviour
{
    public CombatManager CombatManager;
    private int m_curScene;
    public GameObject nextButton;
    public TMP_Text combatText;

    private void Update()
    {
        m_curScene = SceneManager.GetActiveScene().buildIndex;
        if (CombatManager.enemies.Length == 0)
        {
            nextButton.SetActive(true);
            combatText.text = "You Won Congrats";
        }
        else
        {
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
        SceneManager.LoadScene(m_curScene + 1);
    }

}
