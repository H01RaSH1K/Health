using UnityEngine;
using UnityEngine.UI;

public class Damager : HealthAffector
{
    protected override void OnClick()
    {
        _Health.TakeDamage(_HealthAmount);
    }
}
