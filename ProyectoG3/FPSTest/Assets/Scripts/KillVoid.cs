using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillVoid : MonoBehaviour
{
    //Jugador
    [SerializeField]
    Transform player;
    //Altura desde la cual debe caer el jugador
    [SerializeField]
    float height;
    //Punto de restauración
    [SerializeField]
    Transform respawnPoint;

    void Update()
    {
        if (player.transform.position.y < height)
        {
            player.transform.position = respawnPoint.transform.position;
        }
    }
}
