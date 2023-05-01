using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //Singleton
    public static GameManager instance;
    public Score bestScore { get; private set; }
    private string scoreFilePath;
    public string currentPlayerName;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            //Initialize Score fields
            scoreFilePath = Application.persistentDataPath + "/savefile.json";
            LoadBestScore();
        } else {
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    public class Score {
        public string playerName;
        public int score;
    }

    public void SaveBestScore(int score) {
        if (bestScore == null || bestScore.score < score) {
            bestScore = new Score();
            bestScore.playerName = currentPlayerName;
            bestScore.score = score;
            string jsonFile = JsonUtility.ToJson(bestScore);
            File.WriteAllText(scoreFilePath, jsonFile);
        }
    }
    public void LoadBestScore() {
        if (File.Exists(scoreFilePath)) {
            string jsonFile = File.ReadAllText(scoreFilePath);
            bestScore = JsonUtility.FromJson<Score>(jsonFile);
        }
    }

    public string GetBestScoreText(bool oneLine) {
        if (bestScore != null) {
            return "Best score :" + ((oneLine) ? " " : "\n") + bestScore.playerName + " : " + bestScore.score;
        } else {
            return "";
        }
    }

}
