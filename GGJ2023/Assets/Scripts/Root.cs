using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : Interactable
{

    public float size;
    public float maxHealth;
    public ProgressBar healthBar;

    public ParticleSystem healParticles;

    [HideInInspector] public float health;
    private bool interactDown;

    private void Start()
    {
        health = maxHealth;
        healthBar.maxProgress = maxHealth;
        healthBar.SetProgress(health);
        GameManager.Instance.InputManager.OnInteractUp.AddListener(InteractUp);
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
