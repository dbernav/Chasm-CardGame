using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private List<Card> transitionHand = new List<Card>();
    [SerializeField] private Player player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D;

            Vector2 mousePos2D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit2D = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit2D.collider != null)
            {
                Debug.Log("Clicked on " + hit2D.collider.name);
                
                //Card card = 

                //if (card != null)
                
                //Can the player pick cards?
                if (transitionHand.Count < 2)
                {
                    transitionHand.Add(hit2D.collider.GetComponent<CardDisplay>()?.GetComponent<Card>());
                }
                
                //If not, they must discard a card
            }
        }
    }


}
