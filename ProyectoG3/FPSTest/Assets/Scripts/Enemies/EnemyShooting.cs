using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    Transform target;

    //Bala del enemigo
    [SerializeField]
    GameObject projectilePrefab;

    //Sitio de donde dispara
    [SerializeField]
    Transform firePoint;

    //Velocidad de tiro
    [SerializeField]
    float fireTime;

    //Fuente de sonido
    [SerializeField]
    AudioSource soundSource;

    //Sonido de disparo
    [SerializeField]
    AudioClip projectileShot;

    float _currentTime;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= fireTime)
        {
            _currentTime = 0.0F;
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            soundSource.PlayOneShot(projectileShot);
        }
    }
}
