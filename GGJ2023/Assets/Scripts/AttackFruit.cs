using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFruit : Fruit
{
    public override void ActivateEffect()
    {
        Debug.Log("attack damage added");
        host.AttackHandler.AttackDamage += 2;
        GameManager.Instance.UiManager.SetDamageText(host.AttackHandler.AttackDamage.ToString());
    }

}
