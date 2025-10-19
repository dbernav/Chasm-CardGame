//using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

    [SerializeField] Transform _front;
    //Card currCard;

    private void Update()
    {
        if (_front != null)
        {
            DisplayCard(_front.GetComponent<SpriteRenderer>().sprite);
        }
        else
        {
            Debug.LogError("Card is null");
        }
    }

    public void DisplayCard(Sprite img)
    {
        _front.GetComponent<SpriteRenderer>().sprite = img;
    }

    public void ClearDisplay()
    {
        _front.GetComponent<SpriteRenderer>().sprite = null;
    }
}
