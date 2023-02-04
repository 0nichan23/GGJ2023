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
    [SerializeField] private Animator anim;
    private Damageable damageable;

    [HideInInspector] public Root targetRoot;
    private float yVelocity;
    private float timeLeftToAttack;

    private EnemyState enemyState;

    public Damageable Damageable { get => damageable; }

    void Start()
    {
        damageable = GetComponent<Damageable>();
        damageable.Ondeath.AddListener(Explode);
        damageable.OnTakeDamage.AddListener(TakeDamageAnim);
        enemyState = EnemyState.Advancing;
        if (GameManager.Instance.currentDimension == GameManager.Dimensions.Heal)
            Hide();
    }

    private void TakeDamageAnim()
    {
        anim.SetTrigger("TakeDamage");
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
            anim.SetTrigger("Attack");
        }
    }

    public void Explode()
    {
        anim.SetTrigger("Die");
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
