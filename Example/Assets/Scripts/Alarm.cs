using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private Home _home;
 
    private AudioSource _signal;
    private Coroutine _corutine;

    private void OnEnable()
    {      
        _home.StateChanged += OnStateChanged;
    }

    private void OnDisable()
    {
        _home.StateChanged -= OnStateChanged;
    }

    private void Start()
    {
        _signal = GetComponent<AudioSource>();      
    }

    private void OnStateChanged(float value) 
    {       
        if (_corutine != null) 
        {
            StopCoroutine(_corutine);
        }
        _corutine = StartCoroutine(VolumeChange(value));
    }

    private IEnumerator VolumeChange(float volum)
    {             
        while (_signal.volume != volum ) 
        {
            _signal.volume = Mathf.MoveTowards(_signal.volume, volum, Time.deltaTime);
            yield return null;
        }
    }    
}
