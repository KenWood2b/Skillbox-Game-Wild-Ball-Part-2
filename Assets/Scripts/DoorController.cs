using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public Transform door;       // Ссылка на дверь
    public TextMeshProUGUI hintText;        // Текст подсказки
    public float openHeight = 3f; // Высота, на которую дверь открывается
    public float openSpeed = 2f; // Скорость открытия

    private bool isPlayerInTrigger = false; // Флаг нахождения игрока в зоне
    private bool isDoorOpen = false;        // Флаг состояния двери

    void Update()
    {
        // Если игрок в триггере и нажата клавиша E
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            ToggleDoor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Если игрок входит в триггер
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone");
            isPlayerInTrigger = true;
            hintText.enabled = true; // Показать подсказку
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Если игрок выходит из триггера
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger zone");
            isPlayerInTrigger = false;
            hintText.enabled = false; // Скрыть подсказку
        }
    }

    void ToggleDoor()
    {
        if (!isDoorOpen)
        {
            // Открыть дверь
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        isDoorOpen = true;

        Vector3 startPosition = door.position;
        Vector3 targetPosition = startPosition + new Vector3(0, openHeight, 0);

        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            door.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime);
            elapsedTime += Time.deltaTime * openSpeed;
            yield return null;
        }

        door.position = targetPosition;
    }
}
