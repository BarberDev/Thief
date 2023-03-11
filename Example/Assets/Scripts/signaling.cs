using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class signaling : MonoBehaviour
{
    public UnityEvent Signaling;
    AudioSource signal;
    AudioSource sig2nal;


    void Start()
    {
        signal = GetComponent<AudioSource>();

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(volum(-0.1f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Signaling.Invoke();
        StartCoroutine(volum(0.1f));
    }

    IEnumerator volum(float volum)
    {
        for (int i = 0; i < 10; i++)
        {
            signal.volume += Mathf.MoveTowards(0, volum, 1);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
