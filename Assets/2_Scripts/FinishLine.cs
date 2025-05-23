using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float reloadDelay = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("완주했습니다!");
            Invoke(nameof(ReloadScene), reloadDelay);
        }
        
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
