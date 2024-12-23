using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public Transform door;       // ������ �� �����
    public TextMeshProUGUI hintText;        // ����� ���������
    public float openHeight = 3f; // ������, �� ������� ����� �����������
    public float openSpeed = 2f; // �������� ��������

    private bool isPlayerInTrigger = false; // ���� ���������� ������ � ����
    private bool isDoorOpen = false;        // ���� ��������� �����

    void Update()
    {
        // ���� ����� � �������� � ������ ������� E
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            ToggleDoor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���� ����� ������ � �������
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone");
            isPlayerInTrigger = true;
            hintText.enabled = true; // �������� ���������
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ���� ����� ������� �� ��������
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger zone");
            isPlayerInTrigger = false;
            hintText.enabled = false; // ������ ���������
        }
    }

    void ToggleDoor()
    {
        if (!isDoorOpen)
        {
            // ������� �����
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
