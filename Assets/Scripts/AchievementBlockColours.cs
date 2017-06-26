using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AchievementBlockColours : MonoBehaviour
{
    public int achievementID;

	void Start ()
    {
        GetComponent<Image>().color = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<MainMenuAchievements>().blockColours[achievementID * 4];
	}
}
