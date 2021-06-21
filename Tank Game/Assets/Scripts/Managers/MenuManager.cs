using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TankGame.Menus;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public TMP_Dropdown qualityDropdown;
    public TMP_Dropdown resDropdown;
    public Toggle fsToggle;

    private void Start()
    {
        if (qualityDropdown != null)
            MenuFunctions.PopulateQualityPresetDropdown(qualityDropdown);
        if (resDropdown != null)
            MenuFunctions.PopulateResolutionDropdown(resDropdown);
        if (fsToggle != null)
            MenuFunctions.PopulateFullscreenToggle(fsToggle);
    }

    private void Update()
    {
        if(pauseMenu != null && Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
            if(pauseMenu.activeInHierarchy)
                MenuFunctions.PauseProject();
            else
                MenuFunctions.ResumeProject();
        }
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