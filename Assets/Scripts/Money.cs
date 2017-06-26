using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Money : MonoBehaviour
{
    public float money;
    public Text[] moneyText;
    TimeLimit m_timeLimitScript;
    public GameObject addedMoney;
    private Animator m_addMonAnim;
    private Text m_addMonText;
	// Use this for initialization
	void Start ()
    {
        m_addMonAnim = addedMoney.GetComponent<Animator>();
        m_addMonText = addedMoney.GetComponent<Text>();
        LoadMoney();
        m_timeLimitScript = GetComponent<TimeLimit>();
    }

    bool m_isStart = true;
    public GameObject gameOverScreen;
	public void UpdateMoney (float moneyAdded)
    {
        print("updateMoney");
        money += moneyAdded;
        if (money < 0)
            gameOverScreen.SetActive(true);

        if (!m_isStart)
        {
            m_addMonText.text = string.Format("+₽{0}", moneyAdded);
            m_addMonAnim.SetTrigger("Animate");
        }
        m_isStart = false;
        MoneyText();
        m_timeLimitScript.CheckActivities();

	}
    void MoneyText()
    {
        for (int i = 0; i < moneyText.Length; i++)
        {
            moneyText[i].text = string.Format("₽{0}", money);
        }
    }
    void LoadMoney()
    {

    }
}
