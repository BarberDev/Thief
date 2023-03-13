using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] UnityEvent signaling;
    [SerializeField] AudioSource signal;

    private float startingVolume = 0;
    private float maxVolume = 1;
    private float volumeStep = 0.05f;
    private float waiteTime = 0.1f;

    private bool isCorutineRun = false;

    private void Start()
    {
        signal = GetComponent<AudioSource>();

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isCorutineRun == true && collision.gameObject.GetComponent<Thief>())
        {
            StopAllCoroutines();
            StartCoroutine(Volum(-volumeStep));
            isCorutineRun = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isCorutineRun == false && collision.gameObject.GetComponent<Thief>())
        {
            signaling.Invoke();
            StartCoroutine(Volum(volumeStep));
            isCorutineRun = true;
        }
    }

    private IEnumerator Volum(float volum)
    {
        var waiteSeconds = new WaitForSeconds(waiteTime);
        int maxVolumeStep = 10;
        
        for (int i = 0; i < maxVolumeStep; i++)
        {
            signal.volume += Mathf.MoveTowards(startingVolume, volum, maxVolume);

            yield return waiteSeconds;
        }
    }
}
