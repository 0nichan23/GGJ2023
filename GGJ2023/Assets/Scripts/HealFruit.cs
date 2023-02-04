using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealFruit : Fruit
{
    public override void ActivateEffect()
    {
        Debug.Log("heal mod added");
        host.AttackHandler.healModifier += 5;
    }
}
