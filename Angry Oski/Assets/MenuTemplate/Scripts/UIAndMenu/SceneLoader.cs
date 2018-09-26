using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MenuTemp
{
    public class SceneLoader : MonoBehaviour
    {
        /// <summary>
        /// Set the scene to load to be the next of the scene attaching this scrpit.
        /// </summary>
        public Slider LoadSlider;

        public void LoadScene(int sceneIdx)
        {
            StartCoroutine(LoadSceneAsync(sceneIdx));
        }

        IEnumerator LoadSceneAsync(int sceneIdx)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIdx);

            LoadSlider.gameObject.SetActive(true);

            while (!operation.isDone)
            {
                LoadSlider.value = operation.progress;

                yield return null;
            }
        }
    }
}
