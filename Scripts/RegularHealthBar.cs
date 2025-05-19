public class RegularHealthBar : HealthBar
{
    protected override void OnHealthChanged()
    {
        _Slider.value = GetNormalizedHealth();
    }
}
