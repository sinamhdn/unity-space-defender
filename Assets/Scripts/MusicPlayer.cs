using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        // GetType returns type of current class
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
