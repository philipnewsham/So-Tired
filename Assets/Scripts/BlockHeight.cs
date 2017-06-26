using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BlockHeight : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        Invoke("Resize", 0.1f);
	}
	
	// Update is called once per frame
	void Resize ()
    {
        float width = GetComponent<RectTransform>().rect.width;
        print(width);
        //GetComponent<RectTransform>().rect.height = width;

        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(width, width);

        print(GetComponent<RectTransform>().rect.width);
	}
}
