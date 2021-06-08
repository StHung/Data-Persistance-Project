using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;


public class GUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TMP_InputField playerNameInput;

    private void Start()
    {
        bestScoreText.text = DataManager.Instance.BestScoreInfo;
        playerNameInput.text = DataManager.Instance.DataInfo.PlayerName;
    }

    public void StartGame()
    {
        DataManager.Instance.DataInfo.PlayerName = playerNameInput.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        if (Application.isEditor)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit();
        }
    }

}
