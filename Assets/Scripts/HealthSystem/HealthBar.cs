using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float _maxHealth = 100;
    private float _currentHealth;
    [SerializeField] private Image _healthBarFill;
    [SerializeField] private Text _healthText;
   // [SerializeField]
    private float _fillSpeed=50f;
    [SerializeField] private Gradient _colorGradient;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthText.text = "Health : +" + _currentHealth;
    }
    public void UpdateHealth(float amount)
    {
        _currentHealth += amount;
        _currentHealth =Mathf.Clamp(_currentHealth, 0, _maxHealth);
        _healthText.text = "Healtgh : " + _currentHealth;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float targetFillAmount = _currentHealth / _maxHealth;
        _healthBarFill.DOFillAmount(targetFillAmount, _fillSpeed); 
        _healthBarFill.DOColor(_colorGradient.Evaluate(targetFillAmount),_fillSpeed);
    }
}
