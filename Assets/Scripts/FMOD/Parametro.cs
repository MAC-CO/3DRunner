using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parametro : MonoBehaviour
{
    /*private FMOD.Studio.EventInstance instance;
    public FMODUnity.EventReference fmodEvent;
    
    [SerializeField, Range(0f, 1f)] private float Reverb;

    private void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        instance.start();
    }

    void Update()
    {
        instance.setParameterByName("Reverb", Reverb);
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
    }*/

    public void SonidoFireBall()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/FireBall");
    }

    public void SonidoJump()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Jump");
    }

    public void Death()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Death");
    }
    
}