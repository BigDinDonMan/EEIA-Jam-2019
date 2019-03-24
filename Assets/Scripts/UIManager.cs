using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public Text moneyCount = null;
	public static UIManager instance = null;
    public Image healthFill;
    public Image fuelFill;
    public RectTransform gameOverScreen;
    public Text yourScore;
    public Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        gameOverScreen?.gameObject.SetActive(!true);
        UpdateMoney();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        instance = this;
    }

    public void UpdateMoney() {
    	moneyCount.text = string.Format("{0}", Stats.GetInstance().money);
    }

    public void UpdateHealth() {
        healthFill.fillAmount = Stats.GetInstance().health / Stats.GetInstance().maxHealth;
    }

    public void UpdateFuel() {
        fuelFill.fillAmount = Stats.GetInstance().fuel / Stats.GetInstance().maxFuel;
    }

    public void ActivateGameOver() {
        gameOverScreen.gameObject.SetActive(true);
        yourScore.text = string.Format("Your Score: {0}", Stats.GetInstance().money);
        highScore.text = string.Format("High Score: {0}", Stats.GetInstance().money > GameManager.highestCount ? Stats.GetInstance().money : GameManager.highestCount);
    }

    public void DeactivateGameOver() {
        gameOverScreen.gameObject.SetActive(!true);
    }
}
