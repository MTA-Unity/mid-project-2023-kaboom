
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ScoreEntry
{
    public string playerName;
    public int score;
}

public class NameGenerator : MonoBehaviour
{
    private List<string> firstNames = new List<string>
    {
        "Alex", "Bob", "Charlie", "David", "Emma", "Frank", "Grace", "Hannah", "Isaac", "Jack", "Kate", "Liam"
    };

    private List<string> lastNames = new List<string>
    {
        "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Garcia", "Rodriguez", "Martinez"
    };

    private System.Random random = new System.Random();

    public string GenerateRandomName()
    {
        string firstName = firstNames[random.Next(firstNames.Count)];
        string lastName = lastNames[random.Next(lastNames.Count)];
        return $"{firstName} {lastName}";
    }
}



public class ScoreManager : MonoBehaviour
{
    private NameGenerator nameGenerator = new NameGenerator();
    public List<ScoreEntry> topScores = new List<ScoreEntry>();

    private void Awake()
    {
        //LoadScores();
        DontDestroyOnLoad(this);
    }

    public void AddScore(int score)
    {
        string playerName= nameGenerator.GenerateRandomName();
        topScores.Add(new ScoreEntry { playerName = playerName, score = score });
        topScores.Sort((a, b) => b.score.CompareTo(a.score)); // Sort in descending order
        if (topScores.Count > 5)
        {
            topScores.RemoveAt(topScores.Count - 1); // Remove the lowest score
        }
    }

    // public void LoadScores()
    // {
    //     topScores.Clear();
    //     for (int i = 1; i <= 5; i++)
    //     {
    //         string playerName = PlayerPrefs.GetString("PlayerName" + i);
    //         int score = PlayerPrefs.GetInt("PlayerScore" + i);
    //         topScores.Add(new ScoreEntry { playerName = playerName, score = score });
    //     }
    // }

    // public void SaveScores()
    // {
    //     for (int i = 0; i < topScores.Count; i++)
    //     {
    //         PlayerPrefs.SetString("PlayerName" + (i + 1), topScores[i].playerName);
    //         PlayerPrefs.SetInt("PlayerScore" + (i + 1), topScores[i].score);
    //     }
    // }
}
