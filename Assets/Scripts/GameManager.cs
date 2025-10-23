using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Lives { get; private set; }
    public int Score { get; private set; }

    public static event Action<int> LivesChanged;
    public static event Action<int> ScoreChanged;
    
    void Awake()
    {
        // Static instance singleton
        if (Instance != null && Instance != this)
        {
            Debug.Log("Too many game managers, destroying spare");
            Destroy(this.gameObject);
        } 
        else
        {
            Debug.Log("Game Manager initialised");
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    
    void OnEnable()
    {
        Gem.GemCollected += GemCollected;
        Enemy.EnemyDied += EnemyDied;
    }

    void OnDisable()
    {
        Gem.GemCollected -= GemCollected;
        Enemy.EnemyDied -= EnemyDied;
    }

    public void StartNewGame()
    {
        // reset variables/data
        Lives = 3;
        Score = 0;

        // load first scene
        SceneManager.LoadScene("Level-01");
    }

    private void GemCollected() 
    {
        Debug.Log("GM: Gem Collected");
        Score += 5;
        ScoreChanged?.Invoke(Score);
    }

    private void EnemyDied()
    {
        Debug.Log("GM: Enemy Died");
        Score += 10;
        ScoreChanged?.Invoke(Score);
    }
}
