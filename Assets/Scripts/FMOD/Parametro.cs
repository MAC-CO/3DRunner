using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parametro : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    public FMODUnity.EventReference fmodEvent;

    //Parametros para la musica?

    private void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        instance.start();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    
}
