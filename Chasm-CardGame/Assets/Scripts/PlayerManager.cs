using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private List<Card> playerHand = new List<Card>();

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
