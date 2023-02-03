using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum EnemyState
    {
        Advancing,
        Attacking
    }

    public enum EnemyType
    {
        Walking,
        Flying
    }


    public float speed;
    public float gravity;
    public float attackSpeed;
    public float damage;
    public float legsHeight;
    public LayerMask groundLayerMask;
    public ParticleSystem explosionParticle;
    public EnemyType enemyType;
    [SerializeField] private SpriteRenderer rend;

    [HideInInspector] public Root targetRoot;
    private float yVelocity;
    private float timeLeftToAttack;

    private EnemyState enemyState;

    void Start()
    {
        enemyState = EnemyState.Advancing;
        if (GameManager.Instance.currentDimension == GameManager.Dimensions.Heal)
            Hide();
    }


    void Update()
    {
        if (enemyState == EnemyState.Advancing)
        {
            if (enemyType == EnemyType.Walking)
                Walk();
            else
                Fly();
        }
        else
            Attack();
    }
    void Walk()
    {
        if (targetRoot == null)
            return;

        var positionDifference = targetRoot.transform.position - transform.position;
        var xDirection = Mathf.Sign(positionDifference.x);
        var isOnGround = transform.IsOnGround(legsHeight, groundLayerMask);
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

    void Fly()
    {
        if (targetRoot == null)
            return;

        var positionDifference = targetRoot.transform.position - transform.position;
        var direction = positionDifference.normalized;
        var velocity = direction * speed;

        transform.position += velocity * Time.deltaTime;

        var distance = positionDifference.magnitude;
        if (distance < targetRoot.size)
        {
            enemyState = EnemyState.Attacking;
        }
    }

    void Attack()
    {
        if (targetRoot == null)
            return;

        timeLeftToAttack -= Time.deltaTime;

        if (timeLeftToAttack <= 0)
        {
            targetRoot.health -= damage;
            timeLeftToAttack = attackSpeed;
        }
    }

    public void Explode()
    {
        //explosionParticle.Play();
        //explosionParticle.transform.parent = null;
        //Destroy(explosionParticle, explosionParticle.main.duration);
        ParticleEvents particle =  GameManager.Instance.EnemyDeathOP.GetPooledObject();
        particle.transform.position = transform.position;
        particle.gameObject.SetActive(true);
        Destroy(gameObject);
    }

    public void Hide()
    {
        rend.enabled = false;
    }
    public void Reveal()
    {
        rend.enabled = true;
    }
}
