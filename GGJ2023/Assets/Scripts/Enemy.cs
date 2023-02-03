using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum EnemyState
    {
        Walking,
        Attacking
    }


    public float speed;
    public float gravity;
    public float attackSpeed;
    public float damage;
    public float legsHeight;
    
    [HideInInspector] public Root targetRoot;
    private float yVelocity;
    private float timeLeftToAttack;

    private EnemyState enemyState;

    void Start()
    {
        enemyState = EnemyState.Walking;
    }


    void Update()
    {
        if (enemyState == EnemyState.Walking)
            Walk();
        else
            Attack();
    }
    void Walk()
    {
        var positionDifference = targetRoot.transform.position - transform.position;
        var xDirection = Mathf.Sign(positionDifference.x);
        var isOnGround = transform.IsOnGround(legsHeight);
        if (!isOnGround)
            yVelocity -= gravity;
        else
            yVelocity = 0;
        var xVelocity = xDirection * speed;

        var velocity = new Vector3(xVelocity, yVelocity, 0);

        transform.position += velocity * Time.deltaTime;

        var distance = positionDifference.magnitude;
        if (distance < targetRoot.size)
        {
            enemyState = EnemyState.Attacking;
        }
    }

    void Attack()
    {
        timeLeftToAttack -= Time.deltaTime;

        if (timeLeftToAttack <= 0)
        {
            targetRoot.health -= damage;
            timeLeftToAttack = attackSpeed;
        }
    }
}
