using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{

    public float size;
    public float maxHealth;
    public ProgressBar healthBar;

    [HideInInspector] public float health;


    private void Start()
    {
        healthBar.maxProgress = maxHealth;
        healthBar.SetProgress(health);
    }

    private void Update()
    {
        healthBar.SetProgress(health);
    }

}
