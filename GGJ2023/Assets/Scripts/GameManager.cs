using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private PlayerWrapper playerWrapper;
    [SerializeField] private PlayerAttackEffectPool playerAttackObjectPool;
    public InputManager InputManager { get => inputManager; }
    public PlayerWrapper PlayerWrapper { get => playerWrapper; }
    public PlayerAttackEffectPool PlayerAttackObjectPool { get => playerAttackObjectPool; }
}
