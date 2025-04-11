using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButton : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;

    public int counter;
    // Start is called before the first frame update
    void Start()
    {
        page1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == 1)
        {
            page1.SetActive(false);
            page2.SetActive(true);
        }
        if (counter == 2)
        {
            page2.SetActive(false);
            page3.SetActive(true);
        }
        if (counter == 3)
        {
            page3.SetActive(false);
            page4.SetActive(true);
        }
        if(counter == 4)
        {
            SceneManager.LoadScene(0);
        }
        

    }
    public void NextPage()
    {
        counter++;
    }

}
