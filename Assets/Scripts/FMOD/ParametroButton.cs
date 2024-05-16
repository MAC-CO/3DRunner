using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametroButton : MonoBehaviour
{
    public void SonidoButton()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/ClickButton");
    }
}
