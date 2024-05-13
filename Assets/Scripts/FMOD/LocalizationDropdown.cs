using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LocalizationDropdown : MonoBehaviour
{
    public Dropdown localeDropdown;
    private LocalizationSelection localizationSelection; // Referencia al script LocalizationSelection
    private PlayerPrefsManager playerPrefsManager; // Referencia al script PlayerPrefsManager

    //private ScriptUsageProgrammerSounds dialogueScript; // Referencia al script ScriptUsageProgrammerSounds

    void Start()
    {
        localeDropdown = GetComponent<Dropdown>();
        //localeDropdown.onValueChanged.AddListener(OnLocaleDropdownValueChanged);

        // Encontrar los scripts LocalizationSelection y PlayerPrefsManager en la escena
        localizationSelection = FindObjectOfType<LocalizationSelection>();
        playerPrefsManager = FindObjectOfType<PlayerPrefsManager>();

        // Encontrar el script ScriptUsageProgrammerSounds en la escena
        //dialogueScript = FindObjectOfType<ScriptUsageProgrammerSounds>();

        int savedLocaleID = playerPrefsManager.LoadLocaleID();
        localeDropdown.value = savedLocaleID;

        // Comprobar si se encuentran las referencias y manejarlas si es necesario (por ejemplo, imprimir una advertencia)
        if (localizationSelection == null)
        {
            Debug.LogError("¡El script LocalizationSelection no se encontró en la escena!");
        }
        if (playerPrefsManager == null)
        {
            Debug.LogError("¡El script PlayerPrefsManager no se encontró en la escena!");
        }
        //if (dialogueScript == null)
        //{
        //    Debug.LogError("¡El script ScriptUsageProgrammerSounds no se encontró en la escena!");
        //}
    }

    public void OnLocaleDropdownValueChanged()
    {
        //// Verificar si el diálogo está sonando antes de permitir el cambio en el dropdown
        //if (dialogueScript != null && dialogueScript.IsDialoguePlaying())
        //{
        //    // Si el diálogo está sonando, no permitir el cambio en el dropdown
        //    return;
        //}

        int valor = localeDropdown.value;
        localizationSelection.ChangeLocale(valor); // Llamar al método del script LocalizationSelection
        playerPrefsManager.SaveLocaleID(valor); // Guardar el ID del idioma seleccionado en PlayerPrefs
    }

    //void Update()
    //{
    //    // Desactivar el componente TMP_Dropdown si el diálogo está sonando
    //    if (dialogueScript != null && dialogueScript.IsDialoguePlaying())
    //    {
    //        localeDropdown.interactable = false;
    //    }
    //    else
    //    {
    //        localeDropdown.interactable = true;
    //    }
    //}
}