using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private float _currentHealth;
    [SerializeField] private Image _healthBarFill;
   // [SerializeField]
    private float _fillSpeed=1F;
    [SerializeField] private Gradient _colorGradient;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    public void UpdateHealth(float amount)
    {
        _currentHealth += amount;
        _currentHealth =Mathf.Clamp(_currentHealth, 0, _maxHealth);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float targetFillAmount = _currentHealth / _maxHealth;
        _healthBarFill.DOFillAmount(targetFillAmount, _fillSpeed); 
        _healthBarFill.DOColor(_colorGradient.Evaluate(targetFillAmount),_fillSpeed);
    }
}
