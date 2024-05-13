using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LanguageControlledObjectList : MonoBehaviour
{
    // Public list to store GameObjects
    public List<GameObject> myGameObjects = new List<GameObject>();

    // Reference to the LocalizationSelection script
    private LocalizationSelection localizationSelection;

    void Start()
    {
        // Find the LocalizationSelection object in the scene
        localizationSelection = FindObjectOfType<LocalizationSelection>();
    }

    void Update()
    {
        // Check if LocalizationSelection is present and active
        if (localizationSelection != null && !localizationSelection.active)
        {
            // Get the current language index
            int currentLanguageIndex = GetCurrentLanguageIndex();

            // Enable/disable GameObjects based on language index
            for (int i = 0; i < myGameObjects.Count; i++)
            {
                GameObject gameObject = myGameObjects[i];
                gameObject.SetActive(i == currentLanguageIndex);
            }
        }
    }

    /// <summary>
    /// Gets the index of the current language from the Unity Localization package.
    /// </summary>
    /// <returns>The index of the current language, or -1 if no language is selected.</returns>
    private int GetCurrentLanguageIndex()
    {
        if (LocalizationSettings.SelectedLocale == null)
        {
            Debug.LogError("No active locale found in Localization settings!");
            return -1;
        }

        Locale currentLocale = LocalizationSettings.SelectedLocale;
        int languageIndex = LocalizationSettings.AvailableLocales.Locales.IndexOf(currentLocale);
        if (languageIndex < 0)
        {
            Debug.LogWarning("Current locale not found in AvailableLocales!");
            return -1;
        }

        return languageIndex;
    }
}

