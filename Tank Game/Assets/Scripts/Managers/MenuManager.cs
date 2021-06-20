using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TankGame.Menus;

public class MenuManager : MonoBehaviour
{
    public TMP_Dropdown qualityDropdown;
    public TMP_Dropdown resDropdown;
    public Toggle fsToggle;

    private void Start()
    {
        MenuFunctions.PopulateFullscreenToggle(fsToggle);
        MenuFunctions.PopulateQualityPresetDropdown(qualityDropdown);
        MenuFunctions.PopulateResolutionDropdown(resDropdown);
    }

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

    public void PauseProject()
    {
        MenuFunctions.PauseProject();
    }

    public void ResumeProject()
    {
        MenuFunctions.ResumeProject();
    }
}