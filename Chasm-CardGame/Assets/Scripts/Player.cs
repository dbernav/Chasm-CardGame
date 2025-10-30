using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space was pressed");
            playCard(); //this works, but the problem is the game manager shouldnt know about it, nor should it be able to display the card 

        }
    }
    public void playCard()
    {
        Debug.Log("Playing Card...");
        // listen for click on player card
        // if player click 2nd (field) card, delete both cards (player hand, field)
        // if player has no suitable card to pick, play from player hand to field
        //return card; playing the card is one thing, but the logic im trying to work with right now isn't the correct one.
        //let's get to the point where pressing space shows the card, and then let's work on dealing cards face up to each player's hand/
    }
}

