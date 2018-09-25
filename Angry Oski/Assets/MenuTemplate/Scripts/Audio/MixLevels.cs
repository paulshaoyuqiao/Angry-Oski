using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace MenuTemp
{
    public class MixLevels : MonoBehaviour
    {

        public AudioMixer masterMixer;
        static bool isMute = false;

        public Slider musicVolSlider;
        public Slider sfxVolSlider;

        private void Start()
        {
            if (musicVolSlider)
            {
                InitMusicVolSlider();
            }
            if (sfxVolSlider)
            {
                InitSfxVolSlider();
            }
        }

        private void InitMusicVolSlider()
        {
            float vol = 0f;
            masterMixer.GetFloat("muiscVol", out vol);
            musicVolSlider.value = vol;
        }

        private void InitSfxVolSlider()
        {
            float vol = 0f;
            masterMixer.GetFloat("sfxVol", out vol);
            sfxVolSlider.value = vol;
        }

        public void SetSfxLvl(float sfxLvl)
        {
            masterMixer.SetFloat("sfxVol", sfxLvl);
        }

        public void SetMusicLvl(float muiscLvl)
        {
            masterMixer.SetFloat("muiscVol", muiscLvl);
        }

        public void ToggleMuteMixer()
        {
            if (!MixLevels.isMute)
            {
                masterMixer.SetFloat("masterVol", -80.0f);
            }
            else
            {
                masterMixer.SetFloat("masterVol", 0f);
            }
            MixLevels.isMute = !MixLevels.isMute;
        }
    }
}
