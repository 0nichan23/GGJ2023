using System.Linq;
using UnityEngine;

public class PlayerAttackHandler : MonoBehaviour
{
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float attackRadius;
    [SerializeField] private float attackPositionOffset;

    private float lastAttacked;

    private void Start()
    {
        GameManager.Instance.InputManager.OnAttackDown.AddListener(Attack);
        lastAttacked = attackCoolDown * -1;
    }

    private void Attack()
    {
        if (Time.time - lastAttacked < attackCoolDown)
        {
            return;
        }
        lastAttacked = Time.time;
        Collider2D[] foundColliders;
        var attackCenter = transform.position;

        if (GameManager.Instance.PlayerWrapper.Flipper.lookingRight)
            attackCenter += Vector3.right * attackPositionOffset;
        else
            attackCenter += Vector3.left * attackPositionOffset;

        foundColliders = Physics2D.OverlapCircleAll(attackCenter, attackRadius);

        if (GameManager.Instance.currentDimension == GameManager.Dimensions.Attack)
        {
            foreach (var enemyCollider in foundColliders)
            {
                var enemy = enemyCollider.GetComponent<Enemy>();
                if (ReferenceEquals(enemy, null))
                {
                    continue;
                }
                enemy.Explode();
            }
        }
        ParticleEvents particle = GameManager.Instance.AttackParticleOP.GetPooledObject();
        particle.transform.position = attackCenter;
        particle.gameObject.SetActive(true);
       /* else
        {
            //hold function
            var rootColliders = foundColliders.Where(c => c.Is<Root>());
            foreach (var rootCollider in rootColliders)
            {
                var root = rootCollider.GetComponent<Root>();
                root.Heal();
            }
        }

        var totemPosition = GameManager.Instance.totem.transform.position;
        var distanceToTotem = Utils.Distance(totemPosition, attackCenter);

        if (distanceToTotem < attackRadius)
        {
            GameManager.Instance.ToggleDimension();
        }*/
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x + attackPositionOffset, transform.position.y), attackRadius);
        Gizmos.DrawWireSphere(new Vector2(transform.position.x - attackPositionOffset, transform.position.y), attackRadius);
    }


}
