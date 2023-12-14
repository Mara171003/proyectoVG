using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMachineGun : MonoBehaviour
{
    //Velocidad de tiro de la metralleta
    [SerializeField]
    float rateOfFire;
    //Fuente de sonido
    [SerializeField]
    AudioSource audioSource;
    //Sonido del arma
    [SerializeField]
    AudioClip clip;
    //Projectil
    [SerializeField]
    GameObject projectilePrefab;
    //Lugar de donde dispara
    [SerializeField]
    Transform FirePoint;

    float _count;
    bool _inputFire;
    bool _isFiring;

    void Update()
    {
        handleInputs();
        handleFire();
    }

    // Si el jugador presiona el boton izquierdo del mouse, se instancia el projectile seleccionado
    void handleFire()
    {
        if (_isFiring)
        {
            _count -= Time.deltaTime;
            if(_count <= 0)
            {
                _count = rateOfFire;
                audioSource.PlayOneShot(clip);
                Instantiate(projectilePrefab, FirePoint.position, FirePoint.rotation);
            }
        }
        else
        {
            _count -= Time.deltaTime;
        }
    }

    //Maneja entradas del jugador si dispara
    void handleInputs()
    {
        _inputFire = Input.GetButton("Fire1");
        _isFiring = _inputFire != false;
    }
}
