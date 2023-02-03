using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{

    public float size;
    public float maxHealth;
    public ProgressBar healthBar;

    public ParticleSystem healParticles;

    [HideInInspector] public float health;


    private void Start()
    {
        health = maxHealth;
        healthBar.maxProgress = maxHealth;
        healthBar.SetProgress(health);
    }

    private void Update()
    {
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
}
