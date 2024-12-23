using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;    // Ссылка на игрока
    public Vector3 offset;      // Смещение камеры

    void Update()
    {
        // Позиция камеры следует за игроком с фиксированным смещением
        transform.position = player.position + offset;
    }
}
