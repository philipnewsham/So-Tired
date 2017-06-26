using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimeLimit : MonoBehaviour
{
    public float minutesPerDay;
    private float m_secondsInDay = 10f;
    private float m_countDown;
    private bool m_isCounting = false;

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
        print("loadedlevel");
        m_secondsInDay = minutesPerDay * 60f;
        m_countDown = m_secondsInDay;
        m_moneyScript = GetComponent<Money>();
        LoadInformation();
        UpdateDayText();
    }
    public void StartDay()
    {
        m_isCounting = true;
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
                EndOfDay();
        }
    }
    public GameObject endOfDayPanel;
    public Text moneyText;
    public Text[] dayText;
    string[] dayString = new string[5] { "Monday", "Tueday", "Wednesday", "Thursday", "Friday" };
    public AudioSource audioSource;
    public void EndOfDay()
    {
        audioSource.Play();
        m_isCounting = false;
        endOfDayPanel.SetActive(true);
        GetComponent<CheckBlocks>().CheckFinalBlocks();
        m_blocksLeft = GameObject.FindGameObjectsWithTag("Block");
        for (int i = 0; i < m_blocksLeft.Length; i++)
        {
            Destroy(m_blocksLeft[i]);
        }
        m_countDown = m_secondsInDay;
        moneyText.text = string.Format("₽{0}", m_moneyScript.money);
        UpdateDayText();
    }

    void UpdateDayText()
    {
        for (int i = 0; i < dayText.Length; i++)
        {
            dayText[i].text = dayString[currentDay];
        }
    }
    public GameObject endOfWeekPanel;
    public Button[] weekendActivities;
    public GameObject[] startingBlocks;
    public GameObject startDayButton;
    public void NewDay()
    {
        currentDay += 1;
        if (currentDay <= 4)
        {
            
            UpdateDayText();
            m_countDown = m_secondsInDay;
            hourHand.transform.eulerAngles = new Vector3(0, 0, 270);
            minuteHand.transform.eulerAngles = new Vector3(0, 0, 180);
            //GetComponent<SpawnBlocks>().currentSpawn = 0;
            //m_isCounting = true;
            for (int i = 0; i < 4; i++)
            {
                startingBlocks[i].SetActive(true);
            }
            GetComponent<CheckBlocks>().ResetCount();
            SaveInformation();
            startDayButton.SetActive(true);
        }
        else
        {
            endOfWeekPanel.SetActive(true);
            CheckActivities();
        }
    }

    public void CheckActivities()
    {
        float money = m_moneyScript.money;
        for (int i = 0; i < weekendActivities.Length; i++)
        {
            weekendActivities[i].interactable = false;
        }
        weekendActivities[0].interactable = true;
        if (money >= 10)
        {
            weekendActivities[1].interactable = true;
        }
        if (money >= 25)
        {
            weekendActivities[2].interactable = true;
        }
        if (money >= 50)
        {
            weekendActivities[3].interactable = true;
        }
        if (money >= 75)
        {
            weekendActivities[4].interactable = true;
        }
        if (money >= 100)
        {
            weekendActivities[5].interactable = true;
        }
        if (money >= 150)
        {
            weekendActivities[6].interactable = true;
        }
        if (money >= 250)
        {
            weekendActivities[7].interactable = true;
        }
    }

    public void NewWeek()
    {
        currentDay = -1;
        NewDay();
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

