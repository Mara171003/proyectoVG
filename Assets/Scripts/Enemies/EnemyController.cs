using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //Velocidad del enemigo
    [SerializeField]
    float speed;

    //Objetivo del enemigo
    Transform target;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
