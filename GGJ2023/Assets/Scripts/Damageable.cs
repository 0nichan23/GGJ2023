using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField] private int maxHp;
    public UnityEvent<int> OnTakeDamage;
    public UnityEvent<int> OnHealed;
    public UnityEvent Ondeath;

    private int currentHp;

    private void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int amount)
    {
        OnTakeDamage?.Invoke(amount);
        currentHp -= amount;
        ClampHp();
        if (currentHp <= 0)
        {
            Ondeath?.Invoke();
        }
    }

    public void Heal(int amount)
    {
        OnHealed?.Invoke(amount);
        currentHp += amount;
        ClampHp();
    }

    private void ClampHp()
    {
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
    }
}
