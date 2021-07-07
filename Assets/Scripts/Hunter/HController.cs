using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HController : MonoBehaviour
{
    // instance
    public static HController instance;

    void Awake()
    {
        instance = this;
    }

    [SerializeField]
    GameObject[] monsterPrefab = default;

    Vector2 monsterPosition;

    public Triangles[] triangles;      // list of all questions
    int curTriangle;          // current question the player needs to answer

    [SerializeField]
    GameObject playerPrefab = default; // player object
    GameObject player;

    bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
        SetTriangle(0);
        HUI.instance.AssignAnswer();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            HUI.instance.AssignShootPowerText();
        }
    }

    void SetTriangle(int triangle)
    {
        curTriangle = triangle;
        SpawnMonster();
    }

    public void GameOver(bool result)
    {
        isGameOver = true;
        FindObjectOfType<HMenuController>().GameOver(result);
    }
    
    void CorrectAnswer()
    {
        Destroy(GameObject.FindGameObjectWithTag("Monster"));
        FindObjectOfType<HScore>().HUpdateScore();       
        if (triangles.Length - 1 == curTriangle)
        {
            Win();
        }
        else
        {
            SetTriangle(curTriangle + 1);
        }
    }

    public void OnSelectingHypotenuse(int hypotenuse)
    {
        if (!isGameOver)
        {
            if (GettingDirectionOfPlayer() == GettingPositionOfMonster())
            {
                if (hypotenuse == triangles[curTriangle].hypotenuse)
                {                   
                    CorrectAnswer();
                }               
            }
        }
    }

    void Win()
    {
        Time.timeScale = 0.0f;
        GameOver(true);
    }

    void SpawnPlayer()
    {
        Vector2 playerPosition = new Vector2(0, -3);
        Instantiate(playerPrefab, playerPosition, Quaternion.identity);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void SpawnMonster()
    {
        monsterPosition = new Vector2(0, ScreenSizeManager.instance.Height/2);
        int position = Random.Range(0, 3);
        MonsterPositions(position);
        GameObject monster = Instantiate(monsterPrefab[0], monsterPosition, Quaternion.identity);
        monster.GetComponent<Monster>().MonsterPosition = position;
        Text[] edges = monster.GetComponentsInChildren<Text>();
        edges[0].text = HUI.instance.SetFirstEdgeText(triangles[curTriangle]);
        edges[1].text = HUI.instance.SetSecondEdgeText(triangles[curTriangle]);
        
    }

    void MonsterPositions(int horizontal)
    {
        switch (horizontal)
        {
            case 0:
                monsterPosition.x = 0;
                break;
            case 1:
                monsterPosition.x = 3* ScreenSizeManager.instance.Witdh / 4;
                break;
            case 2:
                monsterPosition.x = -3* ScreenSizeManager.instance.Witdh / 4;
                break;           
            default:
                break;
        }
    }

    int GettingDirectionOfPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetInteger("LookingWay");
    }

    int GettingPositionOfMonster()
    {
        return GameObject.FindGameObjectWithTag("Monster").GetComponent<Monster>().MonsterPosition;
    }
}
