using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuAchievements : MonoBehaviour
{
    private bool[] m_haveAchievements = new bool[12];
    public Color[] blockColours = new Color[48];
    public GameObject[] colourGameObjects;
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
    private string[] m_achievementDescriptions = new string[12]
{
        "Complete one day",
        "Complete one week",
        "Watch TV",
        "Watch a film",
        "Have a meal out",
        "Buy a game",
        "Go to a theme park",
        "Go to a gig",
        "Buy a phone",
        "Go on a weekend holiday",
        "Don't make a single tetromino",
        "Every tetromino sent down has the same coloured blocks"
};
    private string[] m_colourScemeNames = new string[12]
    {
        "Basic",
        "Original",
        "Stained Glass",
        "For Kids",
        "Political",
        "Monochrome",
        "Flame",
        "Ocean",
        "Olive Boy",
        "Outrun",
        "Winter Holiday",
        "Self Insert"
    };

    public GameObject[] blockerPanels;
    private Image[] blockerPanelImage = new Image[12];
    private Image[] padlockImage = new Image[12];
    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            Image[] images = blockerPanels[i].GetComponentsInChildren<Image>();
            blockerPanelImage[i] = images[0];
            padlockImage[i] = images[1];
        }

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

        for (int i = 0; i < 12; i++)
        {
            if (m_haveAchievements[i])
            {
                //blockerPanels[i].SetActive(false);
                blockerPanelImage[i].color = new Color(0, 0, 0, 0);
                blockerPanelImage[i].raycastTarget = false;
                padlockImage[i].color = new Color(0, 0, 0, 0);
            }
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

    public Text achievementTextName;
    public Text achievementTextDescription;
    public Text achievementTextColour;
    public Image[] blockImages;
    private int m_currentAchievement;
    public void SelectAchievement(int achievementID)
    {
        for (int i = 0; i < colourGameObjects.Length; i++)
        {
            colourGameObjects[i].SetActive(true);
        }
        m_currentAchievement = achievementID;
        achievementTextName.text = m_achievementNames[achievementID];
        achievementTextDescription.text = m_achievementDescriptions[achievementID];
        achievementTextColour.text = m_colourScemeNames[achievementID];

        for (int i = 0; i < 4; i++)
        {
            blockImages[i].color = blockColours[(4 * achievementID) + i];

        }
    }

    public void ChooseColourScheme()
    {
        PlayerPrefs.SetInt("ColourScheme", m_currentAchievement);
        GetComponent<MainMenu>().LoadColourScheme();
    }

    public void HoverOverBlocker(int blockerNo)
    {
        if (blockerNo != -1)
        {
            achievementTextName.text = m_achievementNames[blockerNo];
            achievementTextDescription.text = "";
            achievementTextColour.text = "";
            for (int i = 0; i < colourGameObjects.Length; i++)
            {
                colourGameObjects[i].SetActive(false);
            }
        }
        else
        {
            achievementTextName.text = "";
            achievementTextDescription.text = "";
            achievementTextColour.text = "";
            for (int i = 0; i < colourGameObjects.Length; i++)
            {
                colourGameObjects[i].SetActive(false);
            }
        }
    }
}
