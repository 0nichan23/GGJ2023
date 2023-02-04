using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedFruit : Fruit
{
    public override void ActivateEffect()
    {
        Debug.Log("Movement speed increased");
        host.Controller.MovementSpeed += 3;
    }
}
