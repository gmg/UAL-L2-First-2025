using UnityEngine;
using System;

public class Gem : MonoBehaviour
{
    public static event Action GemCollected;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            GemCollected?.Invoke();
            Debug.Log("Gem Collected");
        }
    }
}
