using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class gameManager : MonoBehaviour
{


    [SerializeField] GameObject _deck;

    Stack<GameObject> mDeck;
    GameObject[] mCards;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadCards()
    { }
    
    void Shuffle()
    {
        int rand_index;
        GameObject temp;
        for (int lastIndex = mDeck.Count - 1; lastIndex > 0; --lastIndex)
        {
            rand_index = Random.Range(0, lastIndex);
            temp = mCards[lastIndex];
            mCards[lastIndex] = mCards[rand_index];
            mCards[rand_index] = temp;
        }
    }
}
