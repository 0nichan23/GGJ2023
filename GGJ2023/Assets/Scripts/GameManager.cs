using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private InputManager inputManager;

    public InputManager InputManager { get => inputManager; }
}
