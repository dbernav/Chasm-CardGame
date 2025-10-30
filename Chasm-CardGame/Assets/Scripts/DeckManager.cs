using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

// what happens when deck is empty?
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
    [SerializeField] GameObject _mainZone;
    [SerializeField] Card[] _deck;
     

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
        foreach(Card card in _deck)
        {
            if (card != null)
            {
                mDeck.Add(card);
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
        if (mDeck.Count == 0) {Debug.Log("deck is empty" + mDeck.Count); return null; }
        Debug.Log("mDeck Count: " + mDeck.Count);
        Card card = mDeck[0];
        mDeck.RemoveAt(0);
        Debug.Log("Card Taken from Deck. Cards Remaining: " + mDeck.Count);
        return card;
        
    }

    void OnEnable()
    {
        EventManager.onHandCountEmpty += Deal;
        EventManager.onMainFieldEmpty += populateField;
    }

    void OnDisable()
    {
        EventManager.onHandCountEmpty -= Deal;
        EventManager.onMainFieldEmpty -= populateField;
    }

    public void Deal()
    {
        Debug.Log("Dealing Cards");

        Hand p1 = PLAYER_1.GetComponent<Hand>();
        Hand p2 = PLAYER_2.GetComponent<Hand>();
        GameObject pCard;
        Card card;

        Debug.Log("Entering loop");

        for (int i = 0; i < p1.HandSize; ++i)
        {
            Debug.Log("Dealing to Player 1, card " + (i + 1));
            card = TakeCard();
            if (card != null)
            {
                p1.AddToHand(card);
                Debug.Log("Player 1 Hand Count: " + p1.Count);
                pCard = Instantiate(_card, p1.transform.GetChild(i).position, p1.transform.GetChild(i).rotation);
                pCard.transform.SetParent(p1.transform.GetChild(i));
                pCard.GetComponent<CardDisplay>().Initialize(card);
                p1.UpdateHandCount();
            }
            else
            {
                break;
            }
        }
        for (int i = 0; i < p2.HandSize; ++i) //for prototyping - will be hidden in final build
        {
            Debug.Log("Dealing to Player 2, card " + (i + 1));
            card = TakeCard();
            if (card != null)
            {
                p2.AddToHand(card);
                Debug.Log("Player 2 Hand Count: " + p2.Count);
                pCard = Instantiate(_card, p2.transform.GetChild(i).position, p2.transform.GetChild(i).rotation);
                pCard.transform.SetParent(p2.transform.GetChild(i));
                pCard.GetComponent<CardDisplay>().Initialize(card);
                p2.UpdateHandCount();
            }
            else
            {
                break;
            }
        }

        Debug.Log("Exiting loop");
    }
    
    private void populateField()
    {
        Hand mainZone = _mainZone.GetComponent<Hand>();
        GameObject pCard;
        Card card;
       
        for (int i = 0; i < mainZone.HandSize; ++i)
        {
            card = TakeCard();
            if (card != null)
            {
                mainZone.AddToHand(card);
                Debug.Log("Card is " + card.suit + " " + card.rank);
                Debug.Log("Player 1 Hand Count: " + mainZone.Count);
                pCard = Instantiate(_card, mainZone.transform.GetChild(i).position, mainZone.transform.GetChild(i).rotation);
                pCard.transform.SetParent(mainZone.transform.GetChild(i));
                pCard.GetComponent<CardDisplay>().Initialize(card);
                mainZone.UpdateHandCount();
            }
            else { break; }
        }
    }
}
