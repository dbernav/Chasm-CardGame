using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnHandCountEmpty();
    public static event OnHandCountEmpty onHandCountEmpty;

    public static void HandIsEmpty(bool empty)
    {
        if (empty && onHandCountEmpty != null)
        {
            onHandCountEmpty?.Invoke();
            Debug.Log("Hand is empty event triggered");
        }
    }   
}
