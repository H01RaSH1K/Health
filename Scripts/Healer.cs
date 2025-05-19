public class Healer : HealthAffector
{
    protected override void OnClick()
    {
        _health.Heal(_healthAmount);
    }
}
