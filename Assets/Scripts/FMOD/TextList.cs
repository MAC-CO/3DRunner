using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using TMPro;
using UnityEngine.UI;

public class TextList : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjectList;
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;

    private int currentIndex = 0; // Current index in the gameObjectList

    private ScriptUsageProgrammerSounds Dialogo;

    public void Start()
    {
        Dialogo = FindObjectOfType<ScriptUsageProgrammerSounds>(); // Buscar la instancia existente de ScriptUsageProgrammerSounds en la escena

        if (gameObjectList.Count > 0)
        {
            gameObjectList[currentIndex].SetActive(true); // Activate the initial GameObject
        }
    }

    //Funcionamiento Extraño
    /*public void OnPreviousButtonClick()
    {
        // Calculate the new index
        int newIndex = (currentIndex - 1) % gameObjectList.Count;

        // Ensure newIndex stays within the valid range (0 to 3)
        if (newIndex < 0)
        {
            newIndex = gameObjectList.Count - 1; // Wrap around to the last element
        }

        // Update currentIndex and call UpdateActiveGameObject
        currentIndex = newIndex;
        UpdateActiveGameObject();
    }*/

    public void OnNextButtonClick()
    {
        // Verificar si el evento está sonando antes de avanzar al siguiente índice
        if (Dialogo != null && Dialogo.IsDialoguePlaying())
        {
            // Si el evento está sonando, no avanzar al siguiente índice
            return;
        }

        currentIndex = (currentIndex + 1) % gameObjectList.Count;
        UpdateActiveGameObject();
    }

    private void UpdateActiveGameObject()
    {
        if (gameObjectList.Count > 0)
        {
            for (int i = 0; i < gameObjectList.Count; i++)
            {
                gameObjectList[i].SetActive(i == currentIndex);
            }
        }
    }
}
