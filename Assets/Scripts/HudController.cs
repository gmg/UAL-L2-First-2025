using UnityEngine;
using UnityEngine.UIElements;

public class HudController : MonoBehaviour
{
    // UI elements for lives and score
    private VisualElement _root;
    private Label _livesValue;
    private Label _scoreValue;

    void Awake()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
        _livesValue = _root.Q<Label>("LivesValue");
        _scoreValue = _root.Q<Lable>("ScoreValue");
    }

    void OnEnable()
    {
        GameManager.LivesChanged += UpdateLives;
        GameManager.ScoreChanged += UpdateScore;
    }

    void OnDisable()
    {
        GameManager.LivesChanged -= UpdateLives;
        GameManager.ScoreChanged -= UpdateScore;
    }

    // update when lives change
    public void UpdateLives(int lives)
    {
        _livesValue.text = lives.ToString();
    }

    // update when score changes
    public void UpdateScore(int score)
    {
        _scoreValue.text = score.ToString();
    }
}
