using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class HealthBar : HealthView
{
    protected Slider _Slider;

    private void Awake()
    {
        _Slider = GetComponent<Slider>();
    }

    protected float GetNormalizedHealth()
    {
        return (float)_Health.Count / _Health.Max;
    }
}
