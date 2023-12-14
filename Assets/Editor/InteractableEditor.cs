using UnityEditor;

[CustomEditor(typeof(Interactables), true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactables interactable = (Interactables)target;
        if(target.GetType() == typeof(EventOnlyInteractable))
        {
            interactable.displayMessage = EditorGUILayout.TextField("Mensaje", interactable.displayMessage);
            if (interactable.GetComponent<InteractionEvent>() == null)
            {
                interactable.useEvents = true;
                interactable.gameObject.AddComponent<InteractionEvent>();
            }
        }
        else
        {

        base.OnInspectorGUI();
        if (interactable.useEvents)
        {
            //Se utiliza un evento
            if (interactable.GetComponent<InteractionEvent>() == null)
                interactable.gameObject.AddComponent<InteractionEvent>();
        }
        else
        {
            //No se utiliza un evento
            if (interactable.GetComponent<InteractionEvent>() != null)
                DestroyImmediate(interactable.GetComponent<InteractionEvent>());
        }
        }

    }
}
