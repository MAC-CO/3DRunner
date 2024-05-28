using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametoWalkieTalkie : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    public FMODUnity.EventReference fmodEvent;

    [SerializeField] private Light light; // Replace with your light component

    private float intensity = 3f; // Light intensity
    private float EQ = 1f; // Ecualizador
    [SerializeField, Range(0f, 1f)] private float Reverb;

    private float timer = 0f;
    private float changeInterval = 2f; // Intervalo de cambio de intensidad en segundos

    private void Start()
    {
        // Inicializar la instancia del evento FMOD y reproducirlo inmediatamente
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        instance.start();

        // Establecer los valores iniciales de la luz y EQ
        light.intensity = intensity;
        instance.setParameterByName("OnEQ", EQ);
    }

    void Update()
    {
        instance.setParameterByName("Reverb", Reverb);
        // Actualizar el temporizador
        timer += Time.deltaTime;

        // Verificar si ha pasado el intervalo de cambio de intensidad
        if (timer >= changeInterval)
        {
            // Cambiar entre 10 y 0.5 de intensidad y 1 y 0.3 de EQ
            if (light.intensity == 3f)
            {
                light.intensity = 0.5f; // Establecer la intensidad a un valor más bajo
                EQ = 0.5f; // Establecer EQ a un valor más bajo (ejemplo)
            }
            else
            {
                light.intensity = 3f; // Establecer la intensidad de nuevo a 10
                EQ = 1f; // Establecer EQ a un valor más alto (ejemplo)
            }

            // Actualizar el parámetro EQ
            instance.setParameterByName("OnEQ", EQ);

            // Reiniciar el temporizador
            timer = 0f;
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
    
    private void OnDestroy()
    {
        // Detener la instancia del evento FMOD y liberar recursos
        instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        instance.release();
    }
}
