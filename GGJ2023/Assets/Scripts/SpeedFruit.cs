using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedFruit : Fruit
{
    public override void ActivateEffect()
    {
        host.Controller.MovementSpeed += 3;
    }
}
