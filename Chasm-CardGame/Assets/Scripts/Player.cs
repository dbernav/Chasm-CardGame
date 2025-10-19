using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Card> playerHand = new List<Card>();
    public bool handIsEmpty = true; // will be false until hand initialized in final build

    public int Count { get { return playerHand.Count; } }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space was pressed");
            playCard(); //this works, but the problem is the game manager shouldnt know about it, nor should it be able to display the card 

        }
    }
    public void AddToHand(Card card)
    {
        playerHand.Add(card);
    }

    public Player()
    {
        playerHand = new List<Card>();
    }

    public void UpdateHandCount()
    {
        if (playerHand.Count == 6) { handIsEmpty = false; }
    }

    public void playCard()
    {
        Debug.Log("Playing Card...");
        Card card = playerHand[0];
        if (card == null) { Debug.Log("No card to play!"); }
        Debug.Log(string.Format("Card_{0}_{1} played.", card.suit, card.rank));
        //return card; playing the card is one thing, but the logic im trying to work with right now isn't the correct one.
                     //let's get to the point where pressing space shows the card, and then let's work on dealing cards face up to each player's hand/
    }
}

