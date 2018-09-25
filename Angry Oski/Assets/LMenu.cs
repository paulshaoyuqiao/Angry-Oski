using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LMenu : MonoBehaviour {

    public void StartTheL(){
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
    }

    public void GetYourShitTogether(){
        Application.Quit();
    }
}
