using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public enum Dimensions
    {
        Attack,
        Heal
    }

    [SerializeField] private InputManager inputManager;
    [SerializeField] private PlayerWrapper playerWrapper;
    [SerializeField] private PlayerAttackEffectPool attackParticleOP;
    [SerializeField] private EnemyDeathPool enemyDeathOP;
    public InputManager InputManager { get => inputManager; }
    public PlayerWrapper PlayerWrapper { get => playerWrapper; }
    public PlayerAttackEffectPool AttackParticleOP { get => attackParticleOP; }
    public EnemyDeathPool EnemyDeathOP { get => enemyDeathOP; }

    public Dimensions currentDimension;

    public GameObject healBG;
    public GameObject attackBG;
    public GameObject deathBG;

    public Transform totem;
    public ParticleSystem totemActivationParticles;

    private void Start()
    {
        ActivateAttackDimension();
    }

    public void ToggleDimension()
    {
        if (currentDimension == Dimensions.Attack)
        {
            ActivateHealDimension();
            currentDimension = Dimensions.Heal;
        }
        else
        {
            ActivateAttackDimension();
            currentDimension = Dimensions.Attack;
        }

        totemActivationParticles.Restart();
    }
    public void ActivateHealDimension()
    {
        Utils.ForAll<Enemy>(e => e.Hide());
        Utils.ForAll<Root>(r => r.RevealHealth());

        healBG.SetActive(true);
        attackBG.SetActive(false);
    }
    public void ActivateAttackDimension()
    {
        Utils.ForAll<Enemy>(e => e.Reveal());
        Utils.ForAll<Root>(r => r.HideHealth());

        healBG.SetActive(false);
        attackBG.SetActive(true);
    }

    public void GameOver()
    {
        Utils.ForAll<Enemy>(e => Destroy(e.gameObject));
        Utils.ForAll<Root>(r => Destroy(r.gameObject));
        Utils.ForAll<SpawnPoint>(sp => Destroy(sp.gameObject));

        Destroy(playerWrapper.gameObject);
        healBG.SetActive(false);
        attackBG.SetActive(false);
        deathBG.SetActive(true);
    }
}
