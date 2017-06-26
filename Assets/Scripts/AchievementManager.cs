using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AchievementManager : MonoBehaviour
{
    private bool[] m_haveAchievements = new bool[12];
    public Image achievementBlock;
    public Color[] achievementBlockColours = new Color[12];
    public Animator achievementPopUpAnim;
    public Text achievementName;
    private string[] m_achievementNames = new string[12]
    {
        "First day's the toughest",
        "Working for the weekend",
        "Low key weekend",
        "Catch a movie",
        "I'll have the rose",
        "Level up",
        "Swings and roundabouts",
        "They are better live",
        "Ring, ring",
        "A weekend away",
        "They don't pay me enough to work",
        "Gunning for a promotion"
    };
    //complete a day 0
    //complete a week 1
    //Activity one 2
    //Activity two 3
    //Activity three 4
    //Activity four 5
    //Activity five 6
    //Activity six 7
    //Activity seven 8
    //Activity eight 9
    //Do nothing for a day 10
    //All blocks same colour 11
    
	void Start ()
    {
        if (PlayerPrefs.HasKey("DayComplete"))
        {
            int achieve0 = PlayerPrefs.GetInt("DayComplete");
            if (achieve0 == 0)
                m_haveAchievements[0] = false;
            else
                m_haveAchievements[0] = true;

            int achieve1 = PlayerPrefs.GetInt("WeekComplete");
            if (achieve1 == 0)
                m_haveAchievements[1] = false;
            else
                m_haveAchievements[1] = true;

            int achieve2 = PlayerPrefs.GetInt("ActivityOne");
            if (achieve2 == 0)
                m_haveAchievements[2] = false;
            else
                m_haveAchievements[2] = true;

            int achieve3 = PlayerPrefs.GetInt("ActivityTwo");
            if (achieve3 == 0)
                m_haveAchievements[3] = false;
            else
                m_haveAchievements[3] = true;

            int achieve4 = PlayerPrefs.GetInt("ActivityThree");
            if (achieve4 == 0)
                m_haveAchievements[4] = false;
            else
                m_haveAchievements[4] = true;

            int achieve5 = PlayerPrefs.GetInt("ActivityFour");
            if (achieve5 == 0)
                m_haveAchievements[5] = false;
            else
                m_haveAchievements[5] = true;

            int achieve6 = PlayerPrefs.GetInt("ActivityFive");
            if (achieve6 == 0)
                m_haveAchievements[6] = false;
            else
                m_haveAchievements[6] = true;

            int achieve7 = PlayerPrefs.GetInt("ActivitySix");
            if (achieve7 == 0)
                m_haveAchievements[7] = false;
            else
                m_haveAchievements[7] = true;

            int achieve8 = PlayerPrefs.GetInt("ActivitySeven");
            if (achieve8 == 0)
                m_haveAchievements[8] = false;
            else
                m_haveAchievements[8] = true;

            int achieve9 = PlayerPrefs.GetInt("ActivityEight");
            if (achieve9 == 0)
                m_haveAchievements[9] = false;
            else
                m_haveAchievements[9] = true;

            int achieve10 = PlayerPrefs.GetInt("NothingDone");
            if (achieve10 == 0)
                m_haveAchievements[10] = false;
            else
                m_haveAchievements[10] = true;

            int achieve11 = PlayerPrefs.GetInt("SameColour");
            if (achieve11 == 0)
                m_haveAchievements[11] = false;
            else
                m_haveAchievements[11] = true;
        }
        else
        {
            ResetStats();
        }
    }
  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            achievementPopUpAnim.SetTrigger("Achievement");
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            ResetStats();
        }
    }
    public void ResetStats()
    {
        for (int i = 0; i < 12; i++)
        {
            m_haveAchievements[i] = false;
        }

        PlayerPrefs.SetInt("DayComplete", 0);
        PlayerPrefs.SetInt("WeekComplete", 0);
        PlayerPrefs.SetInt("ActivityOne", 0);
        PlayerPrefs.SetInt("ActivityTwo", 0);
        PlayerPrefs.SetInt("ActivityThree", 0);
        PlayerPrefs.SetInt("ActivityFour", 0);
        PlayerPrefs.SetInt("ActivityFive", 0);
        PlayerPrefs.SetInt("ActivitySix", 0);
        PlayerPrefs.SetInt("ActivitySeven", 0);
        PlayerPrefs.SetInt("ActivityEight", 0);
        PlayerPrefs.SetInt("NothingDone", 0);
        PlayerPrefs.SetInt("SameColour", 0);
    }

    public void UnlockedAchievement(int achievementNo)
    {
        if (!m_haveAchievements[achievementNo])
        {
            print(string.Format("achievement {0} achieved!", achievementNo));
            m_haveAchievements[achievementNo] = true;
            switch (achievementNo)
            {
                case 0:
                    PlayerPrefs.SetInt("DayComplete", 1);
                    break;
                case 1:
                    PlayerPrefs.SetInt("WeekComplete", 1);
                    break;
                case 2:
                    PlayerPrefs.SetInt("ActivityOne", 1);
                    break;
                case 3:
                    PlayerPrefs.SetInt("ActivityTwo", 1);
                    break;
                case 4:
                    PlayerPrefs.SetInt("ActivityThree", 1);
                    break;
                case 5:
                    PlayerPrefs.SetInt("ActivityFour", 1);
                    break;
                case 6:
                    PlayerPrefs.SetInt("ActivityFive", 1);
                    break;
                case 7:
                    PlayerPrefs.SetInt("ActivitySix", 1);
                    break;
                case 8:
                    PlayerPrefs.SetInt("ActivitySeven", 1);
                    break;
                case 9:
                    PlayerPrefs.SetInt("ActivityEight", 1);
                    break;
                case 10:
                    PlayerPrefs.SetInt("NothingDone", 1);
                    break;
                case 11:
                    PlayerPrefs.SetInt("SameColour", 1);
                    break;
            }
            achievementName.text = m_achievementNames[achievementNo];
            achievementBlock.color = achievementBlockColours[achievementNo];
            achievementPopUpAnim.SetTrigger("Achievement");
        }
    }
}
