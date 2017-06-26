using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckBlocks : MonoBehaviour
{
    int currentBlockCount;
    public GameObject[] startingPositions;
    public Button dropButton;
    public List<GameObject> currentBlock = new List<GameObject>();
    public Text moneyText;
    public float money;
    private Money m_moneyScript;

    private AudioSource m_audioSource;
    void Start()
    {
        m_moneyScript = GetComponent<Money>();
        m_audioSource = GetComponent<AudioSource>();
    }
    public void AddBlockCount(GameObject currentPiece)
    {
        currentBlockCount += 1;
        currentBlock.Add(currentPiece);
        if(currentBlockCount == 1)
        {
            for (int i = 0; i < startingPositions.Length; i++)
            {
                startingPositions[i].SetActive(false);
            }
        }

        if(currentBlockCount == 4)
        {
            dropButton.interactable = true;
        }
    }
    private int m_blockType;
    private string[] m_blockNames = new string[6] { "line piece", "l piece", "reverse l piece", "z piece", "s piece", "square piece" };
    bool m_matchingColours;
    public int blocksDropped = 0;
    public int sameColourDropped = 0;
    public Animator colourTextAnim;
    public Animator shapeTextAnim;
    private bool[] m_isNewShape = new bool[6];
    private bool m_madeNewShape;
    public void DeleteTetronimo()
    {
        m_audioSource.Play();
        Vector3 placeOrder = new Vector3(currentBlock[1].GetComponent<MoveBlock>().placedInt, currentBlock[2].GetComponent<MoveBlock>().placedInt, currentBlock[3].GetComponent<MoveBlock>().placedInt);
        Vector4 blockColours = new Vector4(currentBlock[0].GetComponent<MoveBlock>().blockColour, currentBlock[1].GetComponent<MoveBlock>().blockColour, currentBlock[2].GetComponent<MoveBlock>().blockColour, currentBlock[3].GetComponent<MoveBlock>().blockColour);
        m_madeNewShape = false;
        //line piece
        if(placeOrder == new Vector3(0,0,0) || placeOrder == new Vector3(1, 1, 1) || placeOrder == new Vector3(2, 2, 2))
        {
            m_blockType = 0;
        }
        //l piece
        if (placeOrder == new Vector3(2, 2, 0) || placeOrder == new Vector3(2, 1, 1) || placeOrder == new Vector3(0, 2, 2) || placeOrder == new Vector3(1,1,2))
        {
            m_blockType = 1;
        }
        //reverse l piece
        if (placeOrder == new Vector3(2, 2, 1) || placeOrder == new Vector3(2, 0, 0) || placeOrder == new Vector3(0, 0, 2) || placeOrder == new Vector3(1, 2, 2))
        {
            m_blockType = 2;
        }
        //z piece
        if (placeOrder == new Vector3(0, 2, 0) || placeOrder == new Vector3(2, 1, 2))
        {
            m_blockType = 3;
        }
        //s piece
        if (placeOrder == new Vector3(1, 2, 1) || placeOrder == new Vector3(2, 0, 2))
        {
            m_blockType = 4;
        }
        //square piece
        if (placeOrder == new Vector3(1, 2, 0) || placeOrder == new Vector3(2, 1, 3) || placeOrder == new Vector3(2, 0, 3) || placeOrder == new Vector3(0, 1, 2))
        {
            m_blockType = 5;
        }

        if (!m_isNewShape[m_blockType])
        {
            m_isNewShape[m_blockType] = true;
            m_madeNewShape = true;
        }

        if (blockColours.x == blockColours.y && blockColours.z == blockColours.w && blockColours.x == blockColours.w)
            m_matchingColours = true;
        else
            m_matchingColours = false;

        print(string.Format("{0}, matching colour = {1}",m_blockNames[m_blockType],m_matchingColours));
        for (int i = 0; i < 4; i++)
        {
            Destroy(currentBlock[i]);            
            startingPositions[i].SetActive(true);
        }
        currentBlock.Clear();

        currentBlockCount = 0;
        blocksDropped += 1;

        int currentBlockWorth = 5;

        if (m_matchingColours)
        {
            colourTextAnim.SetTrigger("Animate");
            currentBlockWorth += 3;
            sameColourDropped += 1;
        }

        if(m_madeNewShape)
        {
            shapeTextAnim.SetTrigger("Animate");
            currentBlockWorth += 2;
        }

        m_moneyScript.UpdateMoney(currentBlockWorth);

        if (blocksDropped == 8)
        {
            GetComponent<TimeLimit>().EndOfDay();
        }

        //MoneyText();
    }

    public void CheckFinalBlocks()
    {
        if (blocksDropped == 0)
            GetComponent<AchievementManager>().UnlockedAchievement(10);

        if(blocksDropped >= 5 && blocksDropped == sameColourDropped)
            GetComponent<AchievementManager>().UnlockedAchievement(11);

        for (int i = 0; i < 6; i++)
        {
            m_isNewShape[i] = false;
        }
        blocksDropped = 0;
    }
    void MoneyText()
    {
        moneyText.text = string.Format("Current Money: ₽{0}", money);
    }

    public void ResetCount()
    {
        currentBlockCount = 0;
        currentBlock.Clear();
    }
}
