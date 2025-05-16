using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : HealthView
{
    [SerializeField] private Image _frontFill;
    [SerializeField] private Image _backFill;
    [SerializeField] private float _fillThreshold = 0.001f;
    [SerializeField] private float _fillAcceleration = 1f;
    [SerializeField] private float _fillDelay = 0.4f;
    
    private float _fillTarget;
    private Image _imageFilling;
    private WaitForSeconds _waitForDelay;
    private Coroutine _fillingCoroutine;

    private void Awake()
    {
        _waitForDelay = new WaitForSeconds(_fillDelay);
    }

    protected override void OnHealthChanged()
    {
        float normalizedHealth = GetNormalizedHealth();

        if (_fillTarget == normalizedHealth)
            return;

        _fillTarget = normalizedHealth;

        if (normalizedHealth < _frontFill.fillAmount)
            ApplyHealthChange(_frontFill, _backFill);
        else
            ApplyHealthChange(_backFill, _frontFill);
    }

    private void ApplyHealthChange(Image imageToFillImmediately, Image imageToFillSmoothly)
    {
        imageToFillImmediately.fillAmount = _fillTarget;

        if (_fillingCoroutine != null)
        {
            if (imageToFillSmoothly == _imageFilling)
                return;
            else
                StopCoroutine(_fillingCoroutine);
        }

        _imageFilling = imageToFillSmoothly;
        StartCoroutine(SmoothlyFillBar());
    }

    private IEnumerator SmoothlyFillBar()
    {
        float velocity = 0f;

        yield return _waitForDelay;

        while (enabled)
        {
            float distanceToTarget = Mathf.Abs(_fillTarget - _imageFilling.fillAmount);
            velocity += _fillAcceleration * Time.deltaTime;
            float movingDistance = velocity * Time.deltaTime;

            if (distanceToTarget < _fillThreshold || movingDistance > distanceToTarget)
            {
                _imageFilling.fillAmount = _fillTarget;
                yield break;
            }

            float direction = Mathf.Sign(_fillTarget - _imageFilling.fillAmount);
            float move = movingDistance * direction;

            _imageFilling.fillAmount = Mathf.Clamp01(_imageFilling.fillAmount + move);
            yield return null;
        }
    }
}
