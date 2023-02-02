using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{

    public float size;
    public float maxHealth;
    public Transform healthBar;

    [HideInInspector] public float health;

    private Vector2 initialHealthBarScale;


    private void Start()
    {
        initialHealthBarScale = healthBar.transform.localScale;
        health = maxHealth;
    }

    private void Update()
    {
        var relativeHealth = health / maxHealth;
        healthBar.transform.localScale = initialHealthBarScale * new Vector2(relativeHealth, 1);
    }

}
