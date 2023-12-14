using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI displayMessage;
    void Start()
    {
        
    }


    public void updateMessage(string message)
    {
        displayMessage.text = message;
    }
}
