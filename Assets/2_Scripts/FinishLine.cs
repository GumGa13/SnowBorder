using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("�����߽��ϴ�!");
        SceneManager.LoadScene(0);
    }
}
