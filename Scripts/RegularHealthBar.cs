public class RegularHealthBar : HealthBar
{
    protected override void OnHealthChanged()
    {
        _slider.value = GetNormalizedHealth();
    }
}
