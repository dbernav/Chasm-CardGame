using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// what happens after hand empty and hand is initially populated?
public class EventManager : MonoBehaviour
{
    public delegate void OnHandCountEmpty();
    public static event OnHandCountEmpty onHandCountEmpty;

    public delegate void OnMainFieldEmpty();
    public static event OnMainFieldEmpty onMainFieldEmpty;
    public static void HandIsEmpty(bool empty)
    {
        if (empty && onHandCountEmpty != null)
        {
            onHandCountEmpty?.Invoke();
            Debug.Log("Hand is empty event triggered");
        }
    }

    public static void FieldIsEmpty(bool empty)
    {
        if (empty && onMainFieldEmpty != null)
        {
            onMainFieldEmpty?.Invoke();
            Debug.Log("Field is empty event triggered");
        }
    }
}
