using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    GameObject[] Panels;
    GameObject[] MMButton;
    int maxLives = 3;

    public void LoadGameScene()
    {
        PlayerPrefs.SetInt("Lives", maxLives);
        SceneManager.LoadScene("ScrollingWorld", LoadSceneMode.Single);
        //additivese suman las dos escenas

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenPanel(Button button)
    {
        button.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        foreach (GameObject b in MMButton)
        {
            if (b != button.gameObject)
            {
                b.SetActive(false);
            }
        }
    }


    public void ClosePanel(Button button)
    {
        button.gameObject.transform.parent.gameObject.SetActive(false);
        foreach (GameObject b in MMButton)
        {
            b.SetActive(true);
        }
    }

    private void Start()
    {
        Panels = GameObject.FindGameObjectsWithTag("Subpanel");
        MMButton = GameObject.FindGameObjectsWithTag("MMButton");

        foreach (GameObject p in Panels)
        {
            p.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            QuitGame();
        }
    }
}
