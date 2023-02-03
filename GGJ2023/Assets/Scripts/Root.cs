using UnityEngine;
using UnityEngine.Events;

public class Root : Interactable
{

    public float size;
    public float maxHealth;
    public ProgressBar healthBar;

    public ParticleSystem healParticles;
    public UnityEvent<Root> OnDeath;

    [HideInInspector] public float health;
    private bool interactDown;


    private void Start()
    {
        health = maxHealth;
        healthBar.maxProgress = maxHealth;
        healthBar.SetProgress(health);
        GameManager.Instance.InputManager.OnInteractUp.AddListener(InteractUp);
        GameManager.Instance.FruitManager.AddRoot(this);
        OnDeath.AddListener(GameManager.Instance.FruitManager.RemoveRoot);
    }

    private void Update()
    {
        if (interactDown)
        {
            health += Time.deltaTime * GameManager.Instance.PlayerWrapper.AttackHandler.healModifier;
        }
        health = Mathf.Clamp(health, 0, maxHealth);

        healthBar.SetProgress(health);
        if (health <= 0)
        {
            //Destroy(gameObject);
            OnDeath?.Invoke(this);
            GameManager.Instance.GameOver();
        }
    }

    public void HideHealth()
    {
        healthBar.gameObject.SetActive(false);
    }
    public void RevealHealth()
    {
        healthBar.gameObject.SetActive(true);
    }

    internal void Heal()
    {
        health = maxHealth;
        healParticles.Restart();
    }

    public override void Interact()
    {
        if (GameManager.Instance.currentDimension == GameManager.Dimensions.Attack)
        {
            return;
        }
        interactDown = true;
    }

    private void InteractUp()
    {
        interactDown = false;
    }
}
