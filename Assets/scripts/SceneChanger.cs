using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string GameScene;
    [SerializeField] private GameObject MainMenuPanel;
    [SerializeField] private GameObject OptionsPanel;

    public void Play()
    {
        SceneManager.LoadScene(GameScene);
    }

    public void OpenOptions()
    {
        MainMenuPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        OptionsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void Quit()
    {
        UnityEngine.Debug.Log("Sair do jogo");
        Application.Quit();
    }
}
