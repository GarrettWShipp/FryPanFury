using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public int fightsBeforeRest;
    public GameManager gameManager;
    public bool shortRest;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManger").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fightsBeforeRest >= gameManager.numberOfFights - 1)
        {
            shortRest = true;
        }
        else
            shortRest = false;
    }
}
