using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Transform infoWindow;
    public Button[] buttons;
    public Transform creditsWindow;

    public void GameStart() => SceneManager.LoadScene(1);
    public void ExitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
    #else 
        Application.Quit();
    #endif
    }
    public void ShowInfo() {
        infoWindow.gameObject.SetActive(true);
        foreach (var button in buttons) button.gameObject.SetActive(false);
    }

    public void HideInfo() {
        infoWindow.gameObject.SetActive(false);
        foreach (var button in buttons) button.gameObject.SetActive(true);
    }

    public void ShowCredits() {
        creditsWindow.gameObject.SetActive(true);
        foreach (var button in buttons) button.gameObject.SetActive(false);
    }

    public void HideCredits() {
        creditsWindow.gameObject.SetActive(!true);
        foreach (var button in buttons) button.gameObject.SetActive(!false);
    }

    private void Start() {
        creditsWindow.gameObject.SetActive(false);
        infoWindow.gameObject.SetActive(false);
    }
}
