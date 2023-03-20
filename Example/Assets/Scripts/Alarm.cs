using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Alarm : MonoBehaviour
{
    private AudioSource signal;

    private float startingVolume = 0;
    private float maxVolume = 1;
    private float volumeStep = 0.05f;
    private float waiteTime = 0.1f;

    private bool isCorutineRun = false;
    private bool isAlarmOn = false;

    private void Start()
    {
        signal = GetComponent<AudioSource>();
    }

    public void Alarming()
    {
        if (isAlarmOn)
        {

            if (isCorutineRun == true)
            {
                StopAllCoroutines();
                StartCoroutine(Volum(-volumeStep));
                isCorutineRun = false;
                isAlarmOn = false;                
            }
        }
        else
        {
            if (isCorutineRun == false)
            {
                StartCoroutine(Volum(volumeStep));
                isCorutineRun = true;
                isAlarmOn = true;
                signal.Play();
            }
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
