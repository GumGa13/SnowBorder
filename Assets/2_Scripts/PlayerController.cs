using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float torqueAmount = 10f; // ȸ������ ũ�� (Inspector���� ���� ����)

    private bool applyLeft = false;  // ���� ȭ��ǥ �Է� ����
    private bool applyRight = false; // ������ ȭ��ǥ �Է� ����

    void Start()
    {
        // Rigidbody2D ������Ʈ�� �����ɴϴ�.
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �Է� ���¸� boolean ������ ������Ʈ
        applyLeft = Input.GetKey(KeyCode.LeftArrow);
        applyRight = Input.GetKey(KeyCode.RightArrow);

        // 3�� �����ڸ� ����Ͽ� Torque�� ����
        ApplyTorque(applyLeft ? torqueAmount : (applyRight ? -torqueAmount : 0f));
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
