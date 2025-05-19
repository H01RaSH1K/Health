using UnityEngine;
using UnityEngine.UI;

public class Damager : HealthAffector
{
    protected override void OnClick()
    {
        _health.TakeDamage(_healthAmount);
    }
}
