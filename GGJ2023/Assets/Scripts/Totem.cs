using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : Interactable
{
    [SerializeField] AudioSource source;
    public override void Interact()
    {
        GameManager.Instance.ToggleDimension();
        source.Play();
    }
}
