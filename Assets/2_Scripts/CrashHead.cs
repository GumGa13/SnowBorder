using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashHead : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �ٴ� ������Ʈ�� "Ground" �±װ� �ִٰ� ����
        if (collision.collider.CompareTag("Ground"))
        {
            Debug.Log("����");
            SceneManager.LoadScene(0);
        }
    }
}
