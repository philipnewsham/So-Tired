using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AchievementGridLayout : MonoBehaviour
{

	// Use this for initialization
	void Awake () {
        float width = Screen.width * 0.6f;
        float height = Screen.height * .45f;
        GetComponent<GridLayoutGroup>().cellSize = new Vector2(width / 4, width/4);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
