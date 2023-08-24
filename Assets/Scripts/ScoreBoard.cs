using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public ScoreManager scoreManager;

    public Text[] scoreTexts;

    void Start()
    {
        scoreManager = GameObject.Find("ScoreScript").GetComponent<ScoreManager>(); 
    }

    void Awake() {
        scoreManager = GameObject.Find("ScoreScript").GetComponent<ScoreManager>(); 
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        for (int i = 0; i < scoreManager.topScores.Count; i++)
        {
            scoreTexts[i].text = $"{scoreManager.topScores[i].playerName}: {scoreManager.topScores[i].score}";
        }
    }
}
