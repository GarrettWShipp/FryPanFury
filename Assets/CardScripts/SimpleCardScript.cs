using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class SimpleCardScript : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite cardImage;
    public string cardType;
    public int manaCost;
    public int attack;
    public int Defensive;
    public InfoType infoType;
}
