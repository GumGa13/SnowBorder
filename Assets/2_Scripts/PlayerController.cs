using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float torqueForce = 3f; //토크의 크기
    private Rigidbody2D rb;
    private SurfaceEffector2D surfaceEffector2D;
    private bool isBoosting = false;

    [SerializeField]
    private float torqueAmount = 10f; // 회전력의 크기 (Inspector에서 설정 가능)

    [SerializeField] float baseSpeed = 5f; // 기본 속도 (Inspector에서 조절 가능)
    [SerializeField] float boostSpeed = 10f; // 부스트 속도 (Inspector에서 조절 가능)

    private bool applyLeft = false;  // 왼쪽 화살표 입력 상태
    private bool applyRight = false; // 오른쪽 화살표 입력 상태

    private enum InputKey
    {
        None, left, Right
    }

    private InputKey currentKey = InputKey.None;

    void Start()
    {
        // Rigidbody2D 컴포넌트를 가져옵니다.
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = Object.FindFirstObjectByType<SurfaceEffector2D>();
    }

    void Update()
    {
        // 입력 상태를 boolean 변수로 업데이트
        applyLeft = Input.GetKey(KeyCode.LeftArrow);
        applyRight = Input.GetKey(KeyCode.RightArrow);

        // 3항 연산자를 사용하여 Torque를 적용
        ApplyTorque(applyLeft ? torqueAmount : (applyRight ? -torqueAmount : 0f));

        currentKey = Input.GetKey(KeyCode.LeftArrow) ?
            InputKey.left :
            Input.GetKey(KeyCode.RightArrow) ? InputKey.Right : InputKey.None;

        isBoosting = Input.GetKey(KeyCode.UpArrow);
    }

    private void FixedUpdate()
    {
        switch(currentKey)
        {
            case InputKey.left:
                rb.AddTorque(torqueForce);
                break;
            case InputKey.Right:
                rb.AddTorque(-torqueForce);
                break;
            default:
                break;
        }

        surfaceEffector2D.speed = isBoosting ? boostSpeed : baseSpeed;
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
