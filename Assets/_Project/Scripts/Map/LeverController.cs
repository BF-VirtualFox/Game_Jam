using UnityEngine;

public class LeverController : MonoBehaviour
{
    [SerializeField] private LayerMask heroLayers;
    [SerializeField] private BossController boss;
    [SerializeField] private Animator animator;

    private bool _isActivated;

    private void Start()
    {
        _isActivated = false;
        disableAnimator();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (heroLayers == (heroLayers | 1 << other.gameObject.layer) && !_isActivated)
        {
            animator.enabled = true;
            Invoke("disableAnimator", 1f);
            _isActivated = true;
            boss.Stun();
        }
    }

    private void disableAnimator()
    {
        animator.enabled = false;
    }
}
