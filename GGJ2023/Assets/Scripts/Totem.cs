using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : Interactable
{
    public override void Interact()
    {
        GameManager.Instance.ToggleDimension();
    }
}
