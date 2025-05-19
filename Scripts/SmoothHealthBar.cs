using System.Collections;
using Unity.VisualScripting;
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
        float distance;
        float move;
        float targetFill;

        do
        {
            targetFill = GetNormalizedHealth();
            float delta = targetFill - _Slider.value;
            distance = Mathf.Abs(delta);
            float direction = Mathf.Sign(delta);

            move = _fillSpeed * Time.deltaTime;

            _Slider.value = Mathf.Clamp(_Slider.value + move * direction, _Slider.minValue, _Slider.maxValue);
            yield return null;
        } while (distance > _fillThreshold && move < distance);

        _Slider.value = targetFill;
        _fillingCoroutine = null;
        yield break;
    }
}
