using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] public UnityEvent OnTriggerEntered;
    [SerializeField] public UnityEvent OnTriggerExited;

    [Tooltip("Tags of objects that can activate this trigger")]
    [SerializeField] private List<string> triggerTags = new List<string> { "Player" };

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsTagMatch(other))
        {
            Debug.Log($"Trigger zone entered by {other.tag}");
            OnTriggerEntered?.Invoke();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (IsTagMatch(other))
        {
            Debug.Log($"Trigger zone exited by {other.tag}");
            OnTriggerExited?.Invoke();
        }
    }

    private bool IsTagMatch(Collider2D other)
    {
        foreach (string tag in triggerTags)
        {
            if (other.CompareTag(tag))
                return true;
        }
        return false;
    }
}