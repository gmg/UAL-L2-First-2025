using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Score;
    
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
    }

    void OnDisable()
    {
        Gem.GemCollected -= GemCollected;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GemCollected() 
    {
        Debug.Log("GM: Gem Collected");
    }
}
