using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Restart() {
    	Stats.GetInstance().ResetStats();
    	GameManager.ResetStaticVars();
    	UIManager.instance.DeactivateGameOver();
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit() => SceneManager.LoadScene(0);
}
