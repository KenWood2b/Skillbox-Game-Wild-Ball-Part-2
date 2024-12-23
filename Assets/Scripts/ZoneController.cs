using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // ���� ������: ���������� ������
        if (other.gameObject.CompareTag("DeathZone"))
        {
            ReloadLevel();
        }

        // ���� ����� �������� � ���� ��������
        if (other.gameObject.CompareTag("LevelExit"))
        {
            StartCoroutine(LoadNextLevelWithDelay(1f)); // ������ �������� � ��������� � 1 �������
        }
    }

    void ReloadLevel()
    {
        // ���������� �������� ������
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator LoadNextLevelWithDelay(float delay)
    {
        // �������� ����� ���������
        yield return new WaitForSeconds(delay);

        // �������� ���������� ������ �� �������
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // ��������, ���� �� ��������� �������
        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
        else
        {
            Debug.Log("��������� ������� �������!");
        }
    }
}
