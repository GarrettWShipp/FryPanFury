using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // Make an instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }
    public void PlayAudio()
    {

    }

    public void StopAudio()
    {

    }
}
