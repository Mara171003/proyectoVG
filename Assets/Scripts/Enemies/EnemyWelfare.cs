using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWelfare : MonoBehaviour
{
    //Cantidad de salud en el enemigo
    [SerializeField]
    float health;

    //El enemigo toma daño y se verifica si muere o no
    public void receiveDamage(float damage)
    {
        Debug.Log(health);
        health -= damage;
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }

    }


}
