using UnityEngine;

public class Gem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Debug.Log("Gem Collected");
        }
    }
}
