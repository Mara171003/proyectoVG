using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Interactables
{
    [SerializeField]
    GameObject healthPickup;

    [SerializeField]
    float timeBeforeInteraction;

    private bool itemPicked = false;

    protected override void interaction()
    {
        itemPicked = true;
        Destroy(healthPickup, timeBeforeInteraction);
        healthPickup.GetComponent<Animator>().SetBool("wasInteracted",itemPicked);
        
    }
}
