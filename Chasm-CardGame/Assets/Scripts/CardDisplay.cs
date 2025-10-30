//using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

    [SerializeField] Transform _front;
    [SerializeField] Sprite img;
    //Card currCard;

    private void Update()
    {
        if(_front != null && img != null)
        {
            DisplayCard();
        }
    }

    public void Initialize(Card card)
    {
        img = card.img;
        _front = this.transform.GetChild(0);
        Debug.Log("CardDisplay initialized with card: " + card._suit + " " + card._rank);
    }

    public void DisplayCard()
    {
        _front.GetComponent<SpriteRenderer>().sprite = img;
    }

    public void ClearDisplay()
    {
        _front.GetComponent<SpriteRenderer>().sprite = null;
    }
}
