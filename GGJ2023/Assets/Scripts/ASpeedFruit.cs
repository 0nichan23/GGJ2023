using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASpeedFruit : Fruit
{
    public override void ActivateEffect()
    {
        Debug.Log("attack speed added");
        host.AttackHandler.AttackCoolDown /= 1.5f;

    }
}
