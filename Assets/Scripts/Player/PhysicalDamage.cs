using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalDamage : MonoBehaviour
{
    [SerializeField]
    float damage;

    //Si el objetco pega con otro y el otro tiene el tag de "Player", aplicara el daño al healthbar.
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.GetComponent<PlayerHealth>().decreaseHealth(damage);
        }
    }
}
