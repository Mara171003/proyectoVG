using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitch : MonoBehaviour
{
    //Fuente de sonido
    [SerializeField]
    AudioSource audioSource;

    //Sonido de selección
    [SerializeField]
    AudioClip clip;

    //Arma actualmente seleccionada
    public int _currentWeapon = 0;

    bool _key1;
    bool _key2;
    bool _key3;
    bool _isKey1;
    bool _isKey2;
    bool _isKey3;

    void Start()
    {
        weaponSelection();
    }

    void Update()
    {
        handleInputs();

        if(_isKey1)
        {
            _currentWeapon = 0;
            weaponSelection();
        }

        if(_isKey2 && transform.childCount >= 2)
        {
            _currentWeapon = 1;
            weaponSelection();
        }

        if (_isKey3 && transform.childCount >= 3)
        {
            _currentWeapon = 2;
            weaponSelection();
        }
    }

    //Selecciona el arma en base al indice actual establecido
    void weaponSelection()
    {
        int index = 0;
        foreach(Transform weapon in transform)
        {
            if(index == _currentWeapon)
            {
                audioSource.PlayOneShot(clip);
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            index++;

        }
    }

    //Entradas del jugador
    void handleInputs()
    {
        _key1 = Input.GetKeyDown(KeyCode.Alpha1);
        _key2 = Input.GetKeyDown(KeyCode.Alpha2);
        _key3 = Input.GetKeyDown(KeyCode.Alpha3);
        _isKey1 = _key1 != false;
        _isKey2 = _key2 != false;
        _isKey3 = _key3 != false;
    }
}
