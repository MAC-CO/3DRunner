//using System.Collections;
//using System.Collections.Generic;

using System;
using UnityEngine;

public class Pasos : MonoBehaviour
{
    private enum TERRENO{Luna, Marte};

    //[SerializeField]
    private TERRENO terreno;
    private FMOD.Studio.EventInstance pasos;
    
    [SerializeField, Range(0f, 1f)] private float Reverb;

    void Update()
    {
        DeterminarTerreno();
    }

    void DeterminarTerreno()
    {
        RaycastHit[] hit;

        hit = Physics.RaycastAll(transform.position, Vector3.down, 10f);

        foreach (RaycastHit rayHit in hit) //ciclo para una sentencia determianda, no es ciclico como el for normal
        {
            if (rayHit.transform.gameObject.layer == LayerMask.NameToLayer("Luna"))
            {
                terreno = TERRENO.Luna;
            }
            else if (rayHit.transform.gameObject.layer == LayerMask.NameToLayer("Marte"))
            {
                terreno = TERRENO.Marte;
            }
        }
    }

    void ReproducirPasos(int terreno)
    {
        pasos = FMODUnity.RuntimeManager.CreateInstance("event:/Pasos");
        pasos.setParameterByName("Planetas", terreno);
        pasos.setParameterByName("Reverb", Reverb);
        pasos.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        pasos.start();
        pasos.release();
    }

    void SeleccionarYReproducirPasos()
    {
        switch (terreno)
        {
            case TERRENO.Luna:
                ReproducirPasos(0);
                Debug.Log("Luna");
                break;
            case TERRENO.Marte:
                ReproducirPasos(1);
                Debug.Log("Marte");
                break;
        }
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

    // void ReproducirPasos_Izq(int terreno)
    // {
    //     pasos = FMODUnity.RuntimeManager.CreateInstance("event:/Pasos");
    //     pasos.setParameterByName("Planeta", terreno);
    //     pasos.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    //     pasos.start();
    //     pasos.release();
    // }
    //
    // void SeleccionarYReproducirPasos_Izq()
    // {
    //     switch (terreno)
    //     {
    //         case TERRENO.Pasto:
    //             ReproducirPasos_Izq(0);
    //             Debug.Log("Pasto Izq");
    //             break;
    //         case TERRENO.Tierra:
    //             ReproducirPasos_Izq(1);
    //             Debug.Log("Tierra Izq");
    //             break;
    //         case TERRENO.Arena:
    //             ReproducirPasos_Izq(2);
    //             Debug.Log("Arena Izq");
    //             break;
    //         case TERRENO.Nada:
    //             ReproducirPasos_Izq(3);
    //             Debug.Log("Nada Izq");
    //             break;
    //         case TERRENO.Aereo:
    //             ReproducirPasos_Izq(4);
    //             Debug.Log("Aereo Izq");
    //             break;
    //     }
    // }


}
