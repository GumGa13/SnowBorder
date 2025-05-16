using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("완주했습니다!");
    }
}
