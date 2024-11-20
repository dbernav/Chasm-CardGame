using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class gameManager : MonoBehaviour
{


    [SerializeField] Transform _deck;

    private List<GameObject> mDeck;
    

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
        foreach (Transform child in _deck)
        {
            mDeck.Add(child.gameObject);
        }
    }
    
    void Shuffle()
    {
        int rand_index;
        GameObject temp;
        for (int lastIndex = mDeck.Count; lastIndex > 0; --lastIndex)
        {
            rand_index = Random.Range(0, lastIndex + 1);
            temp = mDeck[lastIndex];
            mDeck[lastIndex] = mDeck[rand_index];
            mDeck[rand_index] = temp;
        }
    }
}
