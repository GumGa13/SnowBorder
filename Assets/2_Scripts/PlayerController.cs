using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float torqueForce = 3f; //��ũ�� ũ��
    private Rigidbody2D rb;
    private SurfaceEffector2D surfaceEffector2D;
    private bool isBoosting = false;

    [SerializeField]
    private float torqueAmount = 10f; // ȸ������ ũ�� (Inspector���� ���� ����)

    [SerializeField] float baseSpeed = 5f; // �⺻ �ӵ� (Inspector���� ���� ����)
    [SerializeField] float boostSpeed = 10f; // �ν�Ʈ �ӵ� (Inspector���� ���� ����)

    private bool applyLeft = false;  // ���� ȭ��ǥ �Է� ����
    private bool applyRight = false; // ������ ȭ��ǥ �Է� ����

    private enum InputKey
    {
        None, left, Right
    }

    private InputKey currentKey = InputKey.None;

    void Start()
    {
        // Rigidbody2D ������Ʈ�� �����ɴϴ�.
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = Object.FindFirstObjectByType<SurfaceEffector2D>();
    }

    void Update()
    {
        // �Է� ���¸� boolean ������ ������Ʈ
        applyLeft = Input.GetKey(KeyCode.LeftArrow);
        applyRight = Input.GetKey(KeyCode.RightArrow);

        // 3�� �����ڸ� ����Ͽ� Torque�� ����
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
        // Torque�� 0�� �ƴ� ���� ����
        if (torque != 0f)
        {
            rb.AddTorque(torque);
        }
    }
}
