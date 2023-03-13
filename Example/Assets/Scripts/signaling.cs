using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] UnityEvent signaling;
    [SerializeField] AudioSource signal;
    private float waiteTime = 0.1f;

    private void Start()
    {
        signal = GetComponent<AudioSource>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(volum(-0.1f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        signaling.Invoke();
        StartCoroutine(volum(0.1f));
    }

    private IEnumerator volum(float volum)
    {
        var waiteSeconds = new WaitForSeconds(waiteTime);

        for (int i = 0; i < 10; i++)
        {
            signal.volume += Mathf.MoveTowards(0, volum, 1);

            yield return waiteSeconds;
        }
    }
}
