using UnityEngine;

public class PlayerAttackHandler : MonoBehaviour
{
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float attackRadius;
    [SerializeField] private float attackPositionOffset;
    private bool canAttack;

    private float lastAttacked;

    public bool CanAttack { get => canAttack; set => canAttack = value; }


    private void Start()
    {
        GameManager.Instance.InputManager.OnAttackDown.AddListener(Attack);
        CanAttack = true;
        lastAttacked = attackCoolDown * -1;
    }
    public void AddAttackDamage(int amount)
    {
        attackDamage += amount;
    }

    private void Attack()
    {
        if (Time.time - lastAttacked < attackCoolDown || !CanAttack)
        {
            return;
        }
        Debug.Log("Attacking");
        lastAttacked = Time.time;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x + attackPositionOffset, transform.position.y), attackRadius);
        Gizmos.DrawWireSphere(new Vector2(transform.position.x - attackPositionOffset, transform.position.y), attackRadius);
    }


}
