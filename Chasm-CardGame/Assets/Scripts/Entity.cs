using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private List<GameObject> pHand; //player cards
    private List<GameObject> pPile; //player discard pile
    
    void Discard(/*input card to discard, probably by mouse click and/or tap and then pass it in*/ GameObject input)
    {
        pPile.Add(input);
        gameManager.instance.updateGameGoal();
        pHand.Remove(input);
    }

    //Add to hand func
    //Add to pile func (?)
}
