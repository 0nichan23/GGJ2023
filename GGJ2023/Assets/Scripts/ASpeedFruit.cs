using UnityEngine;

public class ASpeedFruit : Fruit
{
    public override void ActivateEffect()
    {
        Debug.Log("attack speed added");
        host.AttackHandler.AttackCoolDown -= (0.4f * 0.1f);
        GameManager.Instance.UiManager.SetAttackSpeedText(host.AttackHandler.AttackCoolDown.ToString("F2"));


    }
}
