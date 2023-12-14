using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProyectiles : MonoBehaviour
{
    //Daño provocado por el projectil
    [SerializeField]
    float projectileDamage;

    //Fuerza con la que se lanza el projectile
    [SerializeField]
    float force;

    //Tiempo de vida del projectile
    float _projectileLifeSpan = 5F;

    //Enemigo que recibe el daño
    EnemyWelfare enemy;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0.0F, force, 0.0F), ForceMode.Force);
        Destroy(this.gameObject, _projectileLifeSpan);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log(collision.gameObject.name);
            enemy = collision.transform.GetComponent<EnemyWelfare>();
            enemy.receiveDamage(projectileDamage);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
