using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parametro : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    public FMODUnity.EventReference fmodEvent;

    private void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        instance.start();
    }

    void Update()
    {
        //instance.setParameterByName("OnEQ", EQ); // Update EQ every frame
    }

    public void SonidoFireBall()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/FireBall");
    }

    public void SonidoJump()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Jump");
        Debug.Log("Salto");
    }

    public void Death()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Death");
    }
    
}
