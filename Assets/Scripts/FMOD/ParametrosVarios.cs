using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametrosVarios : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    private FMOD.Studio.EventInstance instance2;
    public FMODUnity.EventReference fmodEvent;
    public FMODUnity.EventReference fmodEvent2;
    
    [SerializeField, Range(0f, 1f)] private float Reverb;

    private void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        instance2 = FMODUnity.RuntimeManager.CreateInstance(fmodEvent2);
        instance.start();
        instance2.start();
    }

    void Update()
    {
        instance.setParameterByName("Reverb", Reverb);
        instance2.setParameterByName("Reverb", Reverb);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ReverbCueva"))
        {
            print("Reverb Entrada");
            Reverb = 1f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ReverbCueva"))
        {
            print("Reverb Salida");
            Reverb = 0f;
        }
    }
    
}
