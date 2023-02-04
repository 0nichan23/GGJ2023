using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedFruit : Fruit
{
    public override void ActivateEffect()
    {
        Debug.Log("Movement speed increased");
        host.Controller.MovementSpeed += 1;
        GameManager.Instance.UiManager.SetMoveSpeedText(host.Controller.MovementSpeed.ToString());
        host.Controller.MovementSpeed = Mathf.Clamp(host.Controller.MovementSpeed, 0, 16);
        if (host.Controller.MovementSpeed == 16)
        {
            GameManager.Instance.UiManager.SetMoveSpeedText("MAX");
        }
    }
}
