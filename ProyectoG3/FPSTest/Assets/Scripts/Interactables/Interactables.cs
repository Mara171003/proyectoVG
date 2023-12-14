using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactables : MonoBehaviour
{
    //Remover o a�adir eventos de interacci�n a un objeto
    public bool useEvents;

    //Mensaje que se le muestra al jugadora despues de la interacci�n con un objeto
    public string displayMessage;

    //Hace la llamada del metodo desde el jugador
    public void baseInteraction()
    {
        if (useEvents)
        GetComponent<InteractionEvent>()._OnInteraction.Invoke();
        interaction();
    }

    //Plantilla de metodo para ser utilizadas por otras clases que quieran sobreescribir el metodo interaction
    protected virtual void interaction()
    {

    }
}
