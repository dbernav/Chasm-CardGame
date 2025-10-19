using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private List<Card> playerHand = new List<Card>();
    private List<Transform> playerTransform = new List<Transform>(); 

    public int Count { get { return playerHand.Count; } }

    public void AddToHand(Card card)
    {
        playerHand.Add(card);

    }

    public PlayerManager()
    {
        playerHand = new List<Card>();
    }
}
