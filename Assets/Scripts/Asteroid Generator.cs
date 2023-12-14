using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public Transform[] platformTransforms; // Arrastra las plataformas aquí en el Inspector
    public float asteroidDistance = 2f; // Distancia desde la plataforma
    public int numberOfAsteroids = 10;

    void Start()
    {
        GenerateAsteroids();
    }

    void GenerateAsteroids()
    {
        foreach (Transform platformTransform in platformTransforms)
        {
            for (int i = 0; i < numberOfAsteroids; i++)
            {
                Vector3 randomOffset = Random.onUnitSphere * asteroidDistance;
                Vector3 asteroidPosition = platformTransform.position + randomOffset;

                // Comprueba si la posición del asteroide está lo suficientemente lejos de la plataforma
                if (Vector3.Distance(asteroidPosition, platformTransform.position) > asteroidDistance)
                {
                    Instantiate(asteroidPrefab, asteroidPosition, Quaternion.identity);
                }
            }
        }
    }
}