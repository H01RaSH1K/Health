using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected Health _Health;

    private void OnEnable()
    {
        _Health.Changed += OnHealthChanged;
        OnHealthChanged();
    }

    private void OnDisable()
    {
        _Health.Changed -= OnHealthChanged;
    }

    protected abstract void OnHealthChanged();
}
