using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuTemp
{
    public class MainMenuScript : MonoBehaviour
    {

        public SceneLoader loader;

        public void Play()
        {
            loader.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            gameObject.SetActive(false);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
