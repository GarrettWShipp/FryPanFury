using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo : MonoBehaviour
{
    public enum roomType {Normal, Elite, Shop, Event};
    public roomType m_RT = roomType.Normal;
    public int weight;

    private void Start()
    {
        if(m_RT == roomType.Elite  || m_RT == roomType.Shop)
        {
            weight += 1;
        }
    }

}
