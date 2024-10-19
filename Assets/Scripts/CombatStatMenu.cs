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
    public GameObject retry;
    public TMP_Text combatText;

    private void Update()
    {
        m_curScene = SceneManager.GetActiveScene().buildIndex;
        if (CombatManager.combatIsDone)
        {
            nextButton.SetActive(true);
            retry.SetActive(false);
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
        if (SceneManager.GetSceneByBuildIndex(m_curScene + 1) == null)
            SceneManager.LoadScene("MainMenu");
        else
            SceneManager.LoadScene(m_curScene + 1);
    }

}
