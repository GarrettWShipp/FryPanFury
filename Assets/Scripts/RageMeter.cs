using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageMeter : MonoBehaviour
{
    public Image rageMeter;
    public float curRage;
    public float maxRage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rageMeter.fillAmount = curRage / maxRage;
    }
}
