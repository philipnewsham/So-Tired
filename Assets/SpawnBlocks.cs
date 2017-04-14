using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    public Color[] blockColours;
    public int currentDay;
    public GameObject block;
    public Vector2 widthLimit;
    public Vector2 heightLimit;
	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("SpawnBlock", 1, Random.Range(5, 10));
	}

    void SpawnBlock()
    {
        GameObject blockClone = Instantiate(block, new Vector2(Random.Range(widthLimit.x, widthLimit.y), Random.Range(heightLimit.x, heightLimit.y)), Quaternion.identity) as GameObject;
        MoveBlock cloneScript = blockClone.GetComponent<MoveBlock>();
        int chooseColour = Random.Range(0, blockColours.Length);
        blockClone.GetComponent<SpriteRenderer>().color = blockColours[chooseColour];
        cloneScript.blockColour = chooseColour;
    }
}
