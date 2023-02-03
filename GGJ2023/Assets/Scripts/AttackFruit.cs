using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFruit : Fruit
{
    public override void ActivateEffect()
    {
        host.AttackHandler.AttackDamage += 5;
    }

}
