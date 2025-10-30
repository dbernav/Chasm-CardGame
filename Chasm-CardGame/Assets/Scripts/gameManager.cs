using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;


//TO DO:
//PickTwoCards(Collider2D hit2D)
//PlayOneCard(Collider2D hit2D)
//What happens when player hand hits zero after game start? Change dealing logic to indicate game start and then listen for playerHand = 0 to implement new condition.
public class gameManager : MonoBehaviour
{
    [SerializeField] GameObject PLAYER_1;
    [SerializeField] GameObject PLAYER_2;
    [SerializeField] Hand Field;
    [SerializeField] ScoringHand playerScoringHand;
    [SerializeField] ScoringHand oppScoringHand;
    private Hand p1, p2;

    Card testCard;

    private static gameManager _instance;
    public static gameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Assert(false, "gameManager is NULL");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        p1 = PLAYER_1.GetComponent<Hand>();
        p2 = PLAYER_2.GetComponent<Hand>();

        p1.SetHandEmpty(true);
        p2.SetHandEmpty(true);
        Field.SetHandEmpty(true);
    }

    // Update is called once per frame 
    void Update()
    {
       
    }

    public void updateGameGoal()
    {
        if (playerScoringHand.GetScore() == 20)
        {
            Debug.Log("You Win!");
        }
        else if (oppScoringHand.GetScore() == 20)
        {
            Debug.Log("You Lose!");
        }
    }
    void updatePoints()
    {
       
    }

    void Discard()
    {

    }
}
