using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateWorld : MonoBehaviour
{
    public static GameObject dummy;
    public static GameObject lastPlatform;

    void Awake()
    {
        dummy = new GameObject("dummy");
    }

    public static void RunDummy()
    {
        GameObject p = Pool.singleton.GetRandom();
        if (p == null) return;

        if (lastPlatform != null)
        {
            if (lastPlatform.tag == "PlatformT")
            {
                dummy.transform.position = lastPlatform.transform.position + PlayerController.player.transform.forward * 20;
            }
            else
            {
                dummy.transform.position = lastPlatform.transform.position + PlayerController.player.transform.forward * 10;
            }

            if (lastPlatform.tag == "StairsUp")
            {
                dummy.transform.Translate(0, 5, 0);
            }

        }

        lastPlatform = p;
        p.SetActive(true);
        p.transform.position = dummy.transform.position;
        p.transform.rotation = dummy.transform.rotation;

        if (p.tag == "StairsDown")
        {
            dummy.transform.Translate(0, -5, 0);
            p.transform.Rotate(0, 180, 0);
            p.transform.position = dummy.transform.position;
        }

    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
