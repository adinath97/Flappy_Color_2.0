using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int score,randScore;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        randScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(score > PlayerPrefs.GetInt("HighScore",0)) {
            PlayerPrefs.SetInt("HighScore",score);
        }
    }
}
