using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


namespace MenuTemp
{
    public class PauseManager : MonoBehaviour
    {

        public AudioMixerSnapshot paused;
        public AudioMixerSnapshot unpaused;

        public ButtonSFX buttonSFX;

        Canvas canvas;

        void Start()
        {
            canvas = GetComponent<Canvas>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }

        public void Pause()
        {
            if (!canvas.enabled){
                buttonSFX.PlayButtonUpSFX();
            }
            else {
                buttonSFX.PlayButtonDownSFX();
            }
            canvas.enabled = !canvas.enabled;
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
            Lowpass();

        }

        void Lowpass()
        {
            if (Time.timeScale == 0)
            {
                paused.TransitionTo(.01f);
            }

            else

            {
                unpaused.TransitionTo(.01f);
            }
        }

        public void QuitToMenu()
        {
            Pause();
            SceneManager.LoadScene(0);
        }

        public void Quit()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
    		Application.Quit();
#endif
        }
    }
}
