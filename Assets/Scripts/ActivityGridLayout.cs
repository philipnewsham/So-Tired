using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActivityGridLayout : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float width = Screen.width * 0.75f;
        float height = Screen.height * 0.75f;

        GetComponent<GridLayoutGroup>().cellSize = new Vector2(width / 4, height / 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
