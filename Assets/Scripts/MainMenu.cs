using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public Transform gyroInfoWindow;
	public Transform normalWindow;

    public void GameStart() => SceneManager.LoadScene(1);
    public void ExitGame() => Application.Quit();

    private void Start() {
    	if (!SystemInfo.supportsGyroscope) {
    		gyroInfoWindow.gameObject.SetActive(true);
    	} else {
    		normalWindow.gameObject.SetActive(true);
    	}
    }
}
