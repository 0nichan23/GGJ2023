using UnityEngine;

public class PlayerWrapper : MonoBehaviour
{
    [SerializeField] private PlayerAttackHandler attackHandler;
    [SerializeField] private RigidbodyFlipper flipper;
    [SerializeField] private PlayerController controller;
    [SerializeField] private InteractableProximityDetector playerInteractableProximityDetector;
    [SerializeField] private Animator anim;

    public PlayerAttackHandler AttackHandler { get => attackHandler; }
    public RigidbodyFlipper Flipper { get => flipper; }
    public PlayerController Controller { get => controller; }
    public InteractableProximityDetector PlayerInteractableProximityDetector { get => playerInteractableProximityDetector; }
    public Animator Anim { get => anim; }
}
