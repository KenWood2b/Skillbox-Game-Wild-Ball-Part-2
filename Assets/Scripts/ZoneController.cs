using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Зона смерти: перезапуск уровня
        if (other.gameObject.CompareTag("DeathZone"))
        {
            ReloadLevel();
        }

        // Если игрок попадает в зону перехода
        if (other.gameObject.CompareTag("LevelExit"))
        {
            StartCoroutine(LoadNextLevelWithDelay(1f)); // Запуск корутины с задержкой в 1 секунду
        }
    }

    void ReloadLevel()
    {
        // Перезапуск текущего уровня
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator LoadNextLevelWithDelay(float delay)
    {
        // Задержка перед переходом
        yield return new WaitForSeconds(delay);

        // Загрузка следующего уровня по индексу
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Проверка, есть ли следующий уровень
        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
        else
        {
            Debug.Log("Последний уровень пройден!");
        }
    }
}
