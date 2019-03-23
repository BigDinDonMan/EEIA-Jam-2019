using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public Text moneyCount = null;
	public static UIManager instance = null;
    // Start is called before the first frame update
    void Start()
    {
        UpdateMoney();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        instance = this;
    }

    public void UpdateMoney() {
    	moneyCount.text = string.Format("Money: {0}", Stats.GetInstance().money);
    }
}
