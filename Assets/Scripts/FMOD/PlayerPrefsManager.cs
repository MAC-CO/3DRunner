using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    private int defaultLocaleID = 0; // Assuming English as default

    public void SaveLocaleID(int localeID)
    {
        PlayerPrefs.SetInt("LocaleKey", localeID);
    }

    public int LoadLocaleID() // Add this method if needed
    {
        return PlayerPrefs.GetInt("LocaleKey", defaultLocaleID);
    }
}