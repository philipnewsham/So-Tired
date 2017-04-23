using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeLimit : MonoBehaviour
{
    public int minutesPerDay;
    private float m_secondsInDay;
    private float m_countDown;
    private bool m_isCounting = true;

    public GameObject minuteHand;
    private float minuteHandRot;
    public GameObject hourHand;

    private GameObject[] m_blocksLeft;

    public int currentDay;
    private Money m_moneyScript;
    //public Button clockIn;
    // Use this for initialization
    void Start()
    {
        m_secondsInDay = minutesPerDay * 60f;
        m_countDown = m_secondsInDay;
        m_moneyScript = GetComponent<Money>();
        LoadInformation();
        UpdateDayText();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isCounting)
        {
            m_countDown -= Time.deltaTime;
            hourHand.transform.eulerAngles = new Vector3(0, 0, hourHand.transform.eulerAngles.z - ((240/m_secondsInDay) * Time.deltaTime));
            minuteHand.transform.eulerAngles = new Vector3(0, 0, minuteHand.transform.eulerAngles.z - ((2880 / m_secondsInDay) * Time.deltaTime));
            if (m_countDown <= 0f)
            {
                m_isCounting = false;
                EndOfDay();
            }
        }
    }
    public GameObject endOfDayPanel;
    public Text moneyText;
    public Text[] dayText;
    string[] dayString = new string[5] { "Monday", "Tueday", "Wednesday", "Thursday", "Friday" };
    void EndOfDay()
    {
        endOfDayPanel.SetActive(true);
        m_blocksLeft = GameObject.FindGameObjectsWithTag("Block");
        for (int i = 0; i < m_blocksLeft.Length; i++)
        {
            Destroy(m_blocksLeft[i]);
        }
        m_countDown = m_secondsInDay;
        moneyText.text = string.Format("${0}", m_moneyScript.money);
        UpdateDayText();
    }

    void UpdateDayText()
    {
        for (int i = 0; i < dayText.Length; i++)
        {
            dayText[i].text = dayString[currentDay];
        }
    }
    //public Text 
    public void NewDay()
    {
        currentDay += 1;
        UpdateDayText();
        m_countDown = m_secondsInDay;
        hourHand.transform.eulerAngles = new Vector3(0, 0, 270);
        minuteHand.transform.eulerAngles = new Vector3(0, 0, 180);
        GetComponent<SpawnBlocks>().currentSpawn = 0;
        m_isCounting = true;
        SaveInformation();
    }

    void SaveInformation()
    {
        PlayerPrefs.SetInt("Day", currentDay);
        PlayerPrefs.SetFloat("Money", m_moneyScript.money);
    }
    private float m_currentMoney;
    void LoadInformation()
    {
        if(PlayerPrefs.HasKey("Day"))
        {
            currentDay = PlayerPrefs.GetInt("Day");
        }
        else
        {
            currentDay = 0;
        }

        if (PlayerPrefs.HasKey("Money"))
        {
            m_currentMoney = PlayerPrefs.GetFloat("Money");
        }else
        {
            m_currentMoney = 0;
        }
        m_moneyScript.UpdateMoney(m_currentMoney);
    }
}

