using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashHead : MonoBehaviour
{
    [SerializeField] private float reloadDelay = 1f;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip CrashSound;

    private AudioSource audioSource;
    private PlayerController playerController;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerController = GetComponent<PlayerController>();   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Debug.Log("À¡À¡!");

            crashEffect.Play();
            audioSource.PlayOneShot(CrashSound); 
            playerController.GameOver();
            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
