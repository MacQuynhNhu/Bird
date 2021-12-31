using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float spawnTime;
    float m_spawnTime;
    // Start is called before the first frame update
    public Obstacle[] arrObstacle;
    public InCreaseScore IncreasingScore;

    public Obstacle obstacle;
    UIManager uiManager;
    bool isGameover;
    int score;
    bool isReplay;
    void Start()
    {
        m_spawnTime = spawnTime;
        uiManager = FindObjectOfType<UIManager>();
        score = 0;
        uiManager.SetGameoverState(false);
        uiManager.SetTextScore("Score: 0");
    }

    // Update is called once per frame
    void Update()
    {
        m_spawnTime -= Time.deltaTime;
        if(isGameover)
        {
            m_spawnTime = spawnTime;
            uiManager.SetGameoverState(true);
            
            return;
        }
        
        else if(m_spawnTime <= 0)
        {
            isReplay = false;
            Obstacle.dem++;
            InCreaseScore.dem++;
            CreateObstacle();
            
            m_spawnTime = spawnTime;
        }
    }

    void CreateObstacle()
    {
        int i = Random.Range(0, arrObstacle.Length); Debug.Log(i);
        Instantiate(arrObstacle[i], new Vector3(10.23f, -1.7f, 0), Quaternion.identity);
        Instantiate(IncreasingScore, new Vector3(12f, 2.27f, 0), Quaternion.identity);
        
    }
    

    public void IncreaseScore()
    {
        score++;
        uiManager.SetTextScore("Score: " + score.ToString());
    }

    public void Replay()
    {
        isReplay = true;
        uiManager.SetGameoverState(false);
        score = 0;
        uiManager.SetTextScore("Score: 0");
        isGameover = false;
    }
    public bool IsGameover
    {
        get => isGameover;
        set { isGameover = value; }
    }

    public int Score
    {
        get => score;
        set { score = value; }
    }

    public bool IsReplay
    {
        get => isReplay;
        set { isReplay = value; }
    }
}
