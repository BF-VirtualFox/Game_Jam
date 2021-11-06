using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private Light2D light;
    [SerializeField] private int initHealth;
    [SerializeField] private Animator animator;
    [SerializeField] private GameManagerProxy proxy;

    private int _currentHealth;
    public Image[] litTorches;
    public Image[] unlitTorches;
    private bool _isPlayer;
    
    private void OnEnable()
    {
        _isPlayer = light != null;
        _currentHealth = initHealth;
    }


    public void TakeDamage(int damage)
    {
        for(int i=0; i<damage; i++)
        {
            if (_currentHealth <= 1)
                Die();
            if (_isPlayer)
            {
                light.pointLightOuterRadius -= 1;
                litTorches[_currentHealth - 1].enabled = false;
                unlitTorches[_currentHealth - 1].enabled = true;
            }
            _currentHealth -= 1;
        }
    }

    public void Heal(int pv)
    {
        for (int i = 0; i < pv; i++)
        {
            if (_currentHealth < initHealth)
            {
                litTorches[_currentHealth].enabled = true;
                unlitTorches[_currentHealth].enabled = false;
                _currentHealth++;
                light.pointLightOuterRadius++;
            }
        }
    }

    private void Die()
    {
        animator.SetTrigger("die");
        if(_isPlayer)
            proxy.DieMenu();
        Destroy(gameObject,1f);
    }
}
