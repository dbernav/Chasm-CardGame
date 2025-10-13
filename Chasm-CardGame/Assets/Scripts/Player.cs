using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Card> playerHand = new List<Card>();

    public int Count { get { return playerHand.Count; } }

    public void AddToHand(Card card)
    {
        playerHand.Add(card);
    }

    public Player()
    {
        playerHand = new List<Card>();
    }
}

