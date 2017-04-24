using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Money : MonoBehaviour
{
    public float money;
    public Text[] moneyText;
    TimeLimit m_timeLimitScript;
	// Use this for initialization
	void Start ()
    {
        LoadMoney();
        m_timeLimitScript = GetComponent<TimeLimit>();
    }
	
	// Update is called once per frame
	public void UpdateMoney (float moneyAdded) {
        money += moneyAdded;
        MoneyText();
        m_timeLimitScript.CheckActivities();
	}
    void MoneyText()
    {
        for (int i = 0; i < moneyText.Length; i++)
        {
            moneyText[i].text = string.Format("${0}", money);
        }
    }
    void LoadMoney()
    {

    }
}
