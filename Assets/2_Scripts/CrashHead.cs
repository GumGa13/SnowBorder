using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashHead : MonoBehaviour
{
    [SerializeField] private float reloadDelay = 1f;
    [SerializeField] private ParticleSystem crashEffect; // ≈©∑°Ω¨ ¿Ã∆Â∆Æ

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Debug.Log("¿°¿°!");

            crashEffect.Play();

            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
