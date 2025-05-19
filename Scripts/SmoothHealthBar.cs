using System.Collections;
using UnityEngine;

public class SmoothHealthBar : HealthBar
{
    [SerializeField] private float _fillSpeed = 1f;
    [SerializeField] private float _fillThreshold = 0.001f;

    private Coroutine _fillingCoroutine;

    protected override void OnHealthChanged()
    {
        if (_fillingCoroutine == null)
            _fillingCoroutine = StartCoroutine(SmoothlyFill());
    }

    private IEnumerator SmoothlyFill()
    {
        while(enabled)
        {
            float targetFill = GetNormalizedHealth();
            float delta = targetFill - _slider.value;
            float distance = Mathf.Abs(delta);
            float direction = Mathf.Sign(delta);

            float move = _fillSpeed * Time.deltaTime;

            if (distance < _fillThreshold || move > distance)
            {
                _slider.value = targetFill;
                _fillingCoroutine = null;
                yield break;
            }

            _slider.value = Mathf.Clamp(_slider.value + move * direction, _slider.minValue, _slider.maxValue);
            yield return null;
        }
    }
}
