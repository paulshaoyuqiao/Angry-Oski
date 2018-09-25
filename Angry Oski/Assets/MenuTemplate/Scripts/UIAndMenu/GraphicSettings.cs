using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MenuTemp
{
    public class GraphicSettings : MonoBehaviour
    {

        public Dropdown resolutionDropdown;
        public Dropdown qualityDropdown;
        public Toggle fullscreenToggle;

        private Resolution[] resolutions;

        private void Start()
        {
            resolutions = Screen.resolutions;

            if (resolutionDropdown)
            {
                InitResolutionDropdown();
            }
            if (qualityDropdown)
                qualityDropdown.value = QualitySettings.GetQualityLevel();
            if (fullscreenToggle)
                fullscreenToggle.isOn = Screen.fullScreen;
        }

        private void InitResolutionDropdown()
        {

            resolutionDropdown.ClearOptions();

            List<string> s = new List<string>();

            int currentResolutionIdx = 0;
            int i = -1;
            foreach (Resolution r in resolutions)
            {
                s.Add(r.ToString());
                i++;
                if (Screen.currentResolution.Equals(r))
                {
                    currentResolutionIdx = i;
                }
            }
            resolutionDropdown.AddOptions(s);
            resolutionDropdown.value = currentResolutionIdx;
        }

        public void SetGraphicQualityint(int qualityIdx)
        {
            QualitySettings.SetQualityLevel(qualityIdx);
        }

        public void SetFullScreen(bool isFullScreen)
        {
            Screen.fullScreen = isFullScreen;
        }

        public void SetResolution(int resolutionIdx)
        {
            Screen.SetResolution(resolutions[resolutionIdx].width, resolutions[resolutionIdx].height, Screen.fullScreen);
        }
    }
}
