using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("LC: Awake");
    }
    
    void Start()
    {
        Debug.Log("LC: Start");
        Invoke("DestroySelf", 20f);
    }

    void OnEnable()
    {
        Debug.Log("LC: Enable");
    }

    void OnDisable()
    {
        Debug.Log("LC: Disable");
    }

    void OnDestroy()
    {
        Debug.Log("LC: Destroy");
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}

