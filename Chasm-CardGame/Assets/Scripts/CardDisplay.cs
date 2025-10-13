//using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

    [SerializeField] Transform _front;

    public void DisplayCard(Card card)
    {
        if (card != null)
            _front.GetComponent<SpriteRenderer>().sprite = card._img;
        else
            Debug.LogError("Card is null");
    }

    public void ClearDisplay()
    {
        _front.GetComponent<SpriteRenderer>().sprite = null;
    }
}
