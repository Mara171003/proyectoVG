using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    //Fuerza con la que lanza un proyectil
    [SerializeField]
    float force;

    //Jugador
    PlayerUI _player;

    //Tiempo de vida del projectile
    float _projectileLifeSpan = 5.0F;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0.0F, force, 0.0F), ForceMode.Force);
        Destroy(this.gameObject, _projectileLifeSpan);
    }
}
