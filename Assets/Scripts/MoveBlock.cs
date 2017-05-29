using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    bool m_isClicked;
    Vector3 m_mousePosition;
    bool isPlaced;
    Vector2 m_placement;
    bool canBePlaced;
    Vector2 m_startPosition;
    CheckBlocks checkBlockScript;
    public int blockColour;
    private Color thisColour;
    bool m_notFirst;
    public int currentInt;
    public int placedInt;
    private AudioSource m_audioSource;
	void Start ()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_startPosition = transform.position;
        m_placement = m_startPosition;
        checkBlockScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<CheckBlocks>();
        thisColour = GetComponent<SpriteRenderer>().color;
	}
	
	void Update ()
    {
		if(m_isClicked)
        {
            m_mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,0f));
            transform.position = new Vector3(m_mousePosition.x, m_mousePosition.y, 0f);
        }
	}

    GameObject lastBlock;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "StartPosition")
        {
            m_placement = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y + 0.5f);
            canBePlaced = true;
            currentInt = 0;
        }

        if(other.gameObject.tag == "LastBlock")
        {
            m_placement = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y);
            canBePlaced = true;
            lastBlock = other.gameObject;
            m_notFirst = true;
            currentInt = other.gameObject.GetComponentInParent<MoveBlock>().currentInt + 1;
            placedInt = other.gameObject.GetComponent<GhostSide>().side;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "StartPosition" || other.gameObject.tag == "LastBlock")
        {
            m_placement = m_startPosition;
            canBePlaced = false;
        }
    }

    void OnMouseDown()
    {
        if (!isPlaced)
        {
            m_isClicked = true;
            m_audioSource.Play();
        }

    }

    void OnMouseUp()
    {
        m_isClicked = false;
        transform.position = m_placement;

        if (canBePlaced)
        {
            Placed();
        }
        m_audioSource.Play();
    }
    public GameObject[] children;
    void Placed()
    {
        EnableGhost();
        isPlaced = true;
        checkBlockScript.AddBlockCount(gameObject);

        if (m_notFirst)
            lastBlock.GetComponentInParent<MoveBlock>().DisableGhost();
    }

    void EnableGhost()
    {
        //children[1].SetActive()
        for (int i = 0; i < 4; i++)
        {
            children[i].GetComponent<SpriteRenderer>().color = new Color(thisColour.r, thisColour.g, thisColour.b, 0.5f);
        }
        if (currentInt < 3)
        {
            if (transform.position.x != -1.5f)
            {
                if (m_notFirst)
                {
                    if (lastBlock.GetComponent<GhostSide>().side != 1)
                    {
                        children[0].SetActive(true);
                    }
                }
                else
                    children[0].SetActive(true);
            }

            if (transform.position.x != 1.5f)
            {
                if (m_notFirst)
                {
                    if (lastBlock.GetComponent<GhostSide>().side != 0)
                    {
                        children[1].SetActive(true);
                    }
                }
                else
                    children[1].SetActive(true);
            }

            if (transform.position.y != 0.5f)
            {
                if (m_notFirst)
                {
                    if (lastBlock.GetComponent<GhostSide>().side != 3)
                    {
                        children[2].SetActive(true);
                    }
                }
                else
                    children[2].SetActive(true);
            }

            if (transform.position.y != -2.5f)
            {
                if (m_notFirst)
                {
                    if (lastBlock.GetComponent<GhostSide>().side != 2)
                    {
                        children[3].SetActive(true);
                    }
                }
                else
                    children[3].SetActive(true);
            }
        }

        /*for (int i = 0; i < 3; i++)
        {
            children[i].SetActive(true);
            children[i].GetComponent<SpriteRenderer>().color = new Color(thisColour.r, thisColour.g, thisColour.b, 0.5f);
        }

        if (transform.position.y != -2.5f)
            children[3].SetActive(true);
            */
    }

    public void DisableGhost()
    {
        for (int i = 0; i < 4; i++)
        {
            children[i].SetActive(false);
        }
    }
}
