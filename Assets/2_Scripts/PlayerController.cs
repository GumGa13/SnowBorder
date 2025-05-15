using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float torqueAmount = 10f; // 회전력의 크기 (Inspector에서 설정 가능)

    private bool applyLeft = false;  // 왼쪽 화살표 입력 상태
    private bool applyRight = false; // 오른쪽 화살표 입력 상태

    void Start()
    {
        // Rigidbody2D 컴포넌트를 가져옵니다.
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 입력 상태를 boolean 변수로 업데이트
        applyLeft = Input.GetKey(KeyCode.LeftArrow);
        applyRight = Input.GetKey(KeyCode.RightArrow);

        // 3항 연산자를 사용하여 Torque를 적용
        ApplyTorque(applyLeft ? torqueAmount : (applyRight ? -torqueAmount : 0f));
    }

    private void ApplyTorque(float torque)
    {
        // Torque가 0이 아닐 때만 적용
        if (torque != 0f)
        {
            rb.AddTorque(torque);
        }
    }
}
