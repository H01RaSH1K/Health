using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected Health _health;

    private void OnEnable()
    {
        _health.Changed += OnHealthChanged;
        OnHealthChanged();
    }

    private void OnDisable()
    {
        _health.Changed -= OnHealthChanged;
    }

    protected float GetNormalizedHealth()
    {
        return (float)_health.Count / _health.Max;
    }

    protected abstract void OnHealthChanged();
}
