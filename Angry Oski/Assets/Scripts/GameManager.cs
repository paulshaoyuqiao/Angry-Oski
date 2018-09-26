using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    static public int score;
    static public int oskiCount;

    public Text scoreText;
    public Text oskiCountText;


    private void OnEnable()
    {
        score = 0;
        oskiCount = 0;
    }

    void Update () {
        scoreText.text = "SCORE: " + score.ToString();
        oskiCountText.text = "OSKI USED: " + oskiCount.ToString();

    }
}
