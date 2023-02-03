using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealFruit : Fruit
{
    public override void ActivateEffect()
    {
        host.AttackHandler.healModifier += 5;
    }
}
