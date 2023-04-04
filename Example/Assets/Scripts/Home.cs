using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Home : MonoBehaviour
{
    [SerializeField] private Thief thief;
    public UnityAction<float> StateChanged;
   
    int value = 1;  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Thief>())
        {
            StateChanged.Invoke(value);
            thief.ChangePosition();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Thief>())
        {
            StateChanged.Invoke(-value);
            
        }
    }
}
