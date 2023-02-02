using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{

    private void Start()
    {
        GameManager.Instance.InputManager.OnInteractDown.AddListener(Interact);
    }
    private void Interact()
    {
        if (ReferenceEquals(GameManager.Instance.PlayerWrapper.PlayerInteractableProximityDetector.GetClosestLegalTarget(), null))
        {
            return;
        }
        GameManager.Instance.PlayerWrapper.PlayerInteractableProximityDetector.GetClosestLegalTarget().Interact();
    }
}
