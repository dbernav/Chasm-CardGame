using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private List<Card> hand = new List<Card>();
    private bool handIsEmpty = false; 

    [SerializeField] private int handSize;

    public int Count { get { return hand.Count; } } 
    public int HandSize { get { return handSize; } }

    public void SetHandEmpty (bool value) { handIsEmpty = value; }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space was pressed");
            playCard(); //this works, but the problem is the game manager shouldnt know about it, nor should it be able to display the card 

        }
        if (hand.Count == 0 && DeckManager.Instance.DeckInitialized())
        {
            Debug.Log("Player Hand is Empty");
            EventManager.HandIsEmpty(handIsEmpty);
        }
    }
    public void AddToHand(Card card)
    {
        hand.Add(card);
    }

    public void UpdateHandCount()
    {
        if (hand.Count == handSize) { handIsEmpty = false; }
    }

    public void playCard()
    {
        Debug.Log("Playing Card...");
        Card card = hand[0];
        if (card == null) { Debug.Log("No card to play!"); }
        Debug.Log(string.Format("Card_{0}_{1} played.", card.suit, card.rank));
        //return card; playing the card is one thing, but the logic im trying to work with right now isn't the correct one.
        //let's get to the point where pressing space shows the card, and then let's work on dealing cards face up to each player's hand/
    }
}
