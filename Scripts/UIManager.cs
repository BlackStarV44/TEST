using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{

    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;


    private Resolution[] resolutions;

    private void Start()
    {

        resolutions = Screen.resolutions;


        resolutionDropdown.ClearOptions();
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            options.Add(new Dropdown.OptionData(resolutions[i].width + "x" + resolutions[i].height));
        }
        resolutionDropdown.AddOptions(options);


        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                resolutionDropdown.value = i;
                break;
            }
        }


        fullscreenToggle.isOn = Screen.fullScreenMode == FullScreenMode.ExclusiveFullScreen;
    }


    public void OnResolutionChanged(int index)
    {

        Screen.SetResolution(resolutions[index].width, resolutions[index].height, Screen.fullScreenMode);
    }


    public void OnFullscreenToggled(bool isOn)
    {

        Screen.fullScreenMode = isOn ? FullScreenMode.ExclusiveFullScreen : FullScreenMode.Windowed;
    }
}


