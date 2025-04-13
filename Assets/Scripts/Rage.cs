using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rage : MonoBehaviour
{
    public PlayerManager player;
    public GameObject rageMeter;
    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.rageCounter >= rageMeter.GetComponent<RageMeter>().maxRage)
        {
            rageMeter.GetComponent<Button>().interactable = true;
        }
        else
            rageMeter.GetComponent<Button>().interactable = false;

    }
    public void enterRage()
    {
        player.isRaging = true;
    }
}
