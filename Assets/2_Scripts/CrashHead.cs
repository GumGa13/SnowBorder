using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashHead : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 바닥 오브젝트에 "Ground" 태그가 있다고 가정
        if (collision.collider.CompareTag("Ground"))
        {
            Debug.Log("웩웩");
            SceneManager.LoadScene(0);
        }
    }
}
