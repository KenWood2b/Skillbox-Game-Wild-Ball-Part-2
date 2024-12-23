using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // �������� �������� ����
    public float jumpForce = 5f;  // ���� ������

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // �������� ��������� Rigidbody
    }

    void Update()
    {
        // �������� ���� � ����������
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // ������������ ����������� ��������
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // ��������� ���� � Rigidbody ��� ��������
        rb.AddForce(movement * moveSpeed);

        // ������ �� �������
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // �������� ������� � �����
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
