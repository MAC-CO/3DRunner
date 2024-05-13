using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LocalizationSelection : MonoBehaviour
{
    public bool active = false;
    
    public Locale GetCurrentLocale()
    {
        return LocalizationSettings.SelectedLocale;
    }
    public void ChangeLocale(int localeID)
    {
        if (active)
        {
            return;
        }

        StartCoroutine(SetLocale(localeID));
    }

    IEnumerator SetLocale(int _localeID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        active = false;
    }
    
}