public class Healer : HealthAffector
{
    protected override void OnClick()
    {
        Health.TakeHeal(HealthAmount);
    }
}
