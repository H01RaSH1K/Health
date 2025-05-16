using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private int _max;

    public int Count => _count;
    public int Max => _max;

    public event Action Changed;

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            return;

        _count = Math.Max(_count - damage, 0);
        Changed?.Invoke();
    }

    public void Heal(int healthAmount)
    {
        if (healthAmount < 0)
            return;

        _count = Math.Min(_count + healthAmount, _max);
        Changed?.Invoke();
    }
}