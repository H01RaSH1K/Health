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

    protected abstract void OnHealthChanged();
}
