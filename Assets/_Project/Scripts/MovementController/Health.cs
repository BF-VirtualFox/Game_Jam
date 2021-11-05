using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int initHealth;
    [SerializeField] private Animator animator;
    [SerializeField] private GameManagerProxy proxy;
    private int _currentHealth;

    private void OnEnable()
    {
        _currentHealth = initHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        //proxy
        animator.SetTrigger("die");
        Destroy(gameObject,1f);
    }
}
