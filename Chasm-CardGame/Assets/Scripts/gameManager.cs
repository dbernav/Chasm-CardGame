using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class gameManager : MonoBehaviour
{

    public static gameManager instance;

    [SerializeField] Transform _deck; //internal deck - used to load and shuffle deck

    private List<GameObject> mDeck; //main deck

    private int pScore, eScore;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadCards()
    {
        foreach (Transform child in _deck) //grabs children to populate deck array to shuffle
        {
            mDeck.Add(child.gameObject);
        }
    }
    
    void Shuffle() //Fisher-Yates/Knuth Shuffling Algorithm 
    {
        int rand_index;
        GameObject temp;
        for (int lastIndex = mDeck.Count - 1; lastIndex > 0; --lastIndex)
        {
            rand_index = Random.Range(0, lastIndex); 
            temp = mDeck[lastIndex];
            mDeck[lastIndex] = mDeck[rand_index];
            mDeck[rand_index] = temp;
        }
    }

    void Deal()
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
        //
    }

    void Discard()
    {

    }
}
