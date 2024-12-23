using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Скорость движения шара
    public float jumpForce = 5f;  // Сила прыжка

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Получаем компонент Rigidbody
    }

    void Update()
    {
        // Получаем ввод с клавиатуры
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Рассчитываем направление движения
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Применяем силу к Rigidbody для движения
        rb.AddForce(movement * moveSpeed);

        // Прыжок по пробелу
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // Проверка касания с землёй
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
