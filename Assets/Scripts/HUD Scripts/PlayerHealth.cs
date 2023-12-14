using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    Image mugShotNormal;

    [SerializeField]
    Image mugShotDeath;

    [SerializeField]
    Image frontHealthBar;

    [SerializeField]
    Image backHealthBar;


    float _health;
    float _maximumHealth = 100F;
    float _chipSpeed = 2F;
    float _lerpTimer;
    float _fillFrontHealthBar;
    float _fillBackHealthBar;
    float _healthFraction;
    float _completion;


    void Start()
    {
        _health = _maximumHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthUpdate();
        statusUpdate();

    }


    void healthUpdate()
    {
        _fillFrontHealthBar = frontHealthBar.fillAmount;
        _fillBackHealthBar  = backHealthBar.fillAmount;
        _healthFraction = _health/_maximumHealth;
        if (_fillBackHealthBar > _healthFraction)
        {
            frontHealthBar.fillAmount = _healthFraction;
            backHealthBar.color = Color.red;
            _lerpTimer += Time.deltaTime;
            _completion = _lerpTimer / _chipSpeed;
            _completion = _completion * _completion;
            backHealthBar.fillAmount = Mathf.Lerp(_fillBackHealthBar, _healthFraction, _completion);
        }
        if(_fillFrontHealthBar < _healthFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = _healthFraction;
            _lerpTimer += Time.deltaTime;
            _completion = _lerpTimer / _chipSpeed;
            _completion = _completion * _completion;
            frontHealthBar.fillAmount = Mathf.Lerp(_fillFrontHealthBar, backHealthBar.fillAmount, _completion);
        }
    }    

    void statusUpdate()
    {
        if(_health <= 0)
        {
            mugShotNormal.sprite = mugShotDeath.sprite;
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

  public void decreaseHealth(float damage)
    {
        _health -= damage;
        _lerpTimer = 0F;

    }

   public void increaseHealth(float heal)
    {
        _health += heal;
        _lerpTimer = 0F;
    }
}
