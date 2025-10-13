using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class gameManager : MonoBehaviour
{


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
    }

    
    [SerializeField] Transform playerHand;
    public Transform GetPlayerHand() { return playerHand; }

    [SerializeField] Transform opponentHand;

    

    private List<GameObject> mFieldPile;

    public int pScore, eScore, eHandCount = 0;

    public int pHandCount = 0;

   // List<GameObject> topCard = null;
    //GameObject currCard = null;
    
    // Start is called before the first frame update
    void Start()
    {
       
       // DeckManager.LoadCards();

    }

    // Update is called once per frame 
    void Update()
    {
        //topCard.transform.position = Vector2.Lerp(topCard.transform.position, playerHand.transform.position, 0.3f);
        //Debug.Log("card moving to hand");
        if (pHandCount== 0 && DeckManager.Instance.DeckInitialized())
        {
            Debug.Log("Player Hand is Empty");
            EventManager.HandIsEmpty(true);
        }
    }

   

   

    void updateHandCount()
    {

    }

    void Pop(GameObject input)
    { }

    public void updateGameGoal()
    {
        if (pScore == 20)
        {
            Debug.Log("You Win!");
        }
        else if (eScore == 20)
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
