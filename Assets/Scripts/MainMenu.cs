using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Transform infoWindow;
    public Button[] buttons;

    public void GameStart() => SceneManager.LoadScene(1);
    public void ExitGame() => Application.Quit();
    public void ShowInfo() {
        infoWindow.gameObject.SetActive(true);
        foreach (var button in buttons) button.gameObject.SetActive(false);
    }

    public void HideInfo() {
        infoWindow.gameObject.SetActive(false);
        foreach (var button in buttons) button.gameObject.SetActive(true);
    }

    private void Start() {
        infoWindow.gameObject.SetActive(false);
    }
}
