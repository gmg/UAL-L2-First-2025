using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 _input;
    private Rigidbody2D _rb2d;

    [SerializeField]
    private float speed = 6.0f;
    
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue input)
    {
        _input = input.Get<Vector2>();
    }

    void FixedUpdate()
    {
        _rb2d.linearVelocity = _input * speed;
    }
}
