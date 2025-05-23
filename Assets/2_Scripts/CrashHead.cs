using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashHead : MonoBehaviour
{
    [SerializeField] private float reloadDelay = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Debug.Log("À¡À¡!");
            Invoke(nameof(ReloadScene), reloadDelay);
        }

    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
