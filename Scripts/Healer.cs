public class Healer : HealthAffector
{
    protected override void OnClick()
    {
        _Health.TakeHeal(_HealthAmount);
    }
}
