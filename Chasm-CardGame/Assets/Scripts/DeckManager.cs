using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;
public enum SuitEnum
{
    Hearts = 1,
    Clubs = 2,
    Diamonds = 3,
    Spades = 4
}
public class DeckManager : MonoBehaviour
{
    // private char suits = ['C', 'D', 'H', 'S'];

    private static DeckManager _instance;
    public static DeckManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Assert(false, "DeckManager is NULL");
            }
            return _instance;
        }
    }

    [SerializeField] GameObject PLAYER_1; // USER
    [SerializeField] GameObject PLAYER_2; // PLAYER 2 - AI OPPONENT
    [SerializeField] GameObject _card;

    

    public int _deckCount = 52;
    private List<Card> mDeck = new List<Card>();
    private List<Card> mDiscardPile = new List<Card>();

    public int DeckCount() { return mDeck.Count; }
    public bool DeckInitialized() { return mDeck.Count > 0; }
    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        InitializeDeck();
        Shuffle();
    }

    public void InitializeDeck()
    {
        for (int suit = 1; suit <= 4; ++suit)
        {
            for (int rank = 1; rank <= 13; ++rank)
            {
                Card card = ScriptableObject.CreateInstance<Card>();  
                card._suit = (SuitEnum)suit;
                card._rank = rank;
                mDeck.Add(card); //((SuitEnum)suit, rank, Vector3.zero, Quaternion.identity)));
            }
        }
        Debug.Log("Deck Initialized with " + mDeck.Count + " cards.");  
    }

    public void Shuffle() //Fisher-Yates/Knuth Shuffling Algorithm 
    {
        int rand_index;
        Card temp;
        for (int lastIndex = mDeck.Count - 1; lastIndex > 0; --lastIndex)
        {
            rand_index = Random.Range(0, lastIndex);
            temp = mDeck[lastIndex];
            mDeck[lastIndex] = mDeck[rand_index];
            mDeck[rand_index] = temp;
        }
        Debug.Log("Deck Shuffled.");    
    }

    public Card TakeCard()
    {
        //if (mDeck.Count == 0) {Debug.Log("mDeck Count: " + mDeck.Count); return null; }
        Debug.Log("mDeck Count: " + mDeck.Count);
        Card card = mDeck[0];
        mDeck.RemoveAt(0);
        Debug.Log("Card Taken from Deck. Cards Remaining: " + mDeck.Count);
        return card;
        
    }

    void OnEnable()
    {
        EventManager.onHandCountEmpty += Deal;
    }

    void OnDisable()
    {
        EventManager.onHandCountEmpty -= Deal;
    }

    public void Deal()
    {
        Debug.Log("Dealing Cards");

        Player p1 = PLAYER_1.GetComponent<Player>();
        Player p2 = PLAYER_2.GetComponent<Player>();
        GameObject pCard;
        Card card = TakeCard();
        // how do we transfer ownership of the card from the deck manager to the players?
            

        for (int i = 0; i < 6; ++i)
        {
            p1.AddToHand(card);
            Debug.Log("Player 1 Hand Count: " + p1.Count);
            pCard = Instantiate(_card, p1.transform.GetChild(i).position, p1.transform.GetChild(i).rotation);
            p1.UpdateHandCount();
            
        }
        for (int i = 0; i < 6; ++i)
        {
            p2.AddToHand(card);
            Debug.Log("Player 2 Hand Count: " + p2.Count);
            pCard = Instantiate(_card, p2.transform.GetChild(i).position, p2.transform.GetChild(i).rotation);
            p1.UpdateHandCount();
        }
    }
}
