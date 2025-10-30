using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class Card : ScriptableObject
{
    public GameObject _card;

    public SuitEnum _suit;
    public int _rank;
    public Sprite _img;

    public SuitEnum suit { get{ return _suit; } }
    public int rank { get { return _rank; } }
    public Sprite img { get { return _img; } }
    public string getImgName { get { return _img.name; } } 

}
