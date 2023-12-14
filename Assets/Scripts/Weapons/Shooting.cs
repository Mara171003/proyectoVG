using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
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
            audioSource.PlayOneShot(clip);
            Instantiate(projectilePrefab, FirePoint.position, FirePoint.rotation);
        }
    }

    //Maneja entradas del jugador si dispara
    void handleInputs()
    {
        _inputFire = Input.GetButtonDown("Fire1");
        _isFiring = _inputFire != false;
    }
}
