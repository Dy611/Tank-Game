using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TankGame.Menus;

public class MenuManager : MonoBehaviour
{
    public TMP_Dropdown qualityDropdown;
    public TMP_Dropdown resDropdown;
    public Toggle fsToggle;

    //Audio Controller START
    [SerializeField]
    private Settings settingsProfile;

    public static Settings settings;

    private void Awake()
    {
        if (settingsProfile != null)
            settings = settingsProfile;
    }

    private void Start()
    {
        MenuFunctions.PopulateFullscreenToggle(fsToggle);
        MenuFunctions.PopulateQualityPresetDropdown(qualityDropdown);
        MenuFunctions.PopulateResolutionDropdown(resDropdown);

        if (settings && settings.audioMixer != null)
            settings.LoadAudioLevels();
    }
    //Audio Controller END

    public void CloseProject()
    {
        MenuFunctions.ExitProject();
    }

    public void SetQuality(int index)
    {
        MenuFunctions.SetQualityPreset(index);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        MenuFunctions.SetFullScreen(isFullscreen);
    }

    public void SetResolution(int index)
    {
        MenuFunctions.SetResolution(index);
    }

    public void LoadScene(int sceneIndex)
    {
        MenuFunctions.LoadScene(sceneIndex);
    }
}