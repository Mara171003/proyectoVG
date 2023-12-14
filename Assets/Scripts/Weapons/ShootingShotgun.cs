using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingShotgun : MonoBehaviour
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
    //Lugares de donde dispara la escopeta
    [SerializeField]
    Transform FirePointA;
    //Lugares de donde dispara la escopeta
    [SerializeField]
    Transform FirePointB;
    //Lugares de donde dispara la escopeta
    [SerializeField]
    Transform FirePointC;
    //Lugares de donde dispara la escopeta
    [SerializeField]
    Transform FirePointD;
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
            Instantiate(projectilePrefab, FirePointA.position, FirePointA.rotation);
            Instantiate(projectilePrefab, FirePointB.position, FirePointB.rotation);
            Instantiate(projectilePrefab, FirePointC.position, FirePointC.rotation);
            Instantiate(projectilePrefab, FirePointD.position, FirePointD.rotation);
        }
    }

    //Maneja entradas del jugador si dispara
    void handleInputs()
    {
        _inputFire = Input.GetButtonDown("Fire1");
        _isFiring = _inputFire != false;
    }
}
