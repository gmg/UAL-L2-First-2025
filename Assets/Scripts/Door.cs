using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject doorGraphic;

    private bool locked = false;

    private Coroutine delayCoroutine;
    
    public void ToggleLock()
    {
        locked = !locked;
    }
    
    public void Open()
    {
        if (locked) return;
        doorGraphic.SetActive(false);
    }

    public void Close()
    {
        doorGraphic.SetActive(true);
    }

    public void CloseAfterDelay(float delay)
    {
        if(delayCoroutine != null)
        {
            StopCoroutine(delayCoroutine);
        }
        
        delayCoroutine = StartCoroutine(DelayedClose(delay));
    }

    IEnumerator DelayedClose(float delay)
    {
        yield return new WaitForSeconds(delay);
        Close();
    }
}
