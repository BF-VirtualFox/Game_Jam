using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering.Universal;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private Light2D light;
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
        if (light != null)
            light.pointLightOuterRadius -= damage;
        if (_currentHealth <= 0)
            Die();
        
    }

    public void Heal(int amount)
    {
        if (_currentHealth < initHealth)
        {
            var newAmount = amount;
            if (_currentHealth + amount > initHealth)
                newAmount = initHealth - _currentHealth;
            _currentHealth += newAmount;
            light.pointLightOuterRadius += newAmount;
        }
        Debug.Log("Cant Heal, your current health is too high");
            
    }

    private void Die()
    {
        //proxy
        animator.SetTrigger("die");
        Destroy(gameObject,1f);
    }
}
