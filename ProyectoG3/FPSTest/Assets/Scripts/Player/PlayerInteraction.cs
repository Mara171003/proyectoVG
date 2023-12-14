using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private float rayDistance = 3F;

    [SerializeField]
    private LayerMask mask;

    private Camera _cam;
    private PlayerUI _playerUI;
    private InputActionAsset _inputManager;



    
    void Start()
    {
        _cam = Camera.main;
        _playerUI = GetComponent<PlayerUI>();
        _inputManager = GetComponent<InputActionAsset>();
    }
    void Update()
    {
        _playerUI.updateMessage(string.Empty);

        Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance);
        RaycastHit rayHitFeedback; //Información de lo que pasa cuando el rayo colisiona
        if(Physics.Raycast(ray,out rayHitFeedback, rayDistance, mask))
        {
            if(rayHitFeedback.collider.GetComponent<Interactables>() != null)
            {
                Interactables interactable = rayHitFeedback.collider.GetComponent<Interactables>();
               _playerUI.updateMessage(interactable.displayMessage);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    interactable.baseInteraction();
                }
                
            }
        }
    }
}
