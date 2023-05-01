using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour {
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI errorMessage;

    private void Start() {
        //Show best score
        bestScoreText.SetText(GameManager.instance.GetBestScoreText(false));
    }

    public void ChangeCurrentPlayerName(string playerName) {
        if (!string.IsNullOrEmpty(playerName)) {
            GameManager.instance.currentPlayerName = playerName;
            errorMessage.gameObject.SetActive(false);
        } else {
            errorMessage.gameObject.SetActive(true);
        }
    }
    public void StartGame() {
        if (string.IsNullOrEmpty(GameManager.instance.currentPlayerName)) {
            errorMessage.gameObject.SetActive(true);
        } else {
            SceneManager.LoadScene("main");
        }
    }
    public void ExitGame() {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
