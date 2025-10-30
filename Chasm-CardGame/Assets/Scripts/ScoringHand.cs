using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoringHand : Hand
{
    private int score;

    public int GetScore () { return score; }

    private Dictionary<SuitEnum, int> collectedCards = new Dictionary<SuitEnum, int>()
    {
        {SuitEnum.Hearts, 0},
        {SuitEnum.Clubs, 0},
        {SuitEnum.Diamonds, 0},
        {SuitEnum.Spades, 0}
    };

    public void AddToScore(Card card1, Card card2)
    {
        collectedCards[card1.suit] = collectedCards[card1.suit] + 1;
        collectedCards[card2.suit] = collectedCards[card2.suit] + 1;
    }

    public void Tally()
    {
        score = collectedCards.Values.Max() - collectedCards.Values.Min();
        Debug.Log("Cards added, new score: " + score);
    }
}
