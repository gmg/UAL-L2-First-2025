using UnityEngine;
using UnityEngine.UIElements;

public class TitleScreenController : MonoBehaviour
{
    private VisualElement _root;
    private Button _startBTN;

    void Awake()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
        _startBTN = _root.Q<Button>("StartBTN");
    }

    void OnEnable()
    {
        _startBTN.clicked += StartNewGame;
    }

    void OnDisable()
    {
        _startBTN.clicked -= StartNewGame;
    }

    void StartNewGame()
    {
        Debug.Log("New Game Started");
        GameManager.Instance.StartNewGame();
    }
}
