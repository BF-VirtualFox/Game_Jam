using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FirebowlActivator : MonoBehaviour
{
    [SerializeField] private Light2D light;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask heroLayers;
    [SerializeField] private int heal;

    private bool _canHeal = true;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (heroLayers == (heroLayers | 1 << other.gameObject.layer) && _canHeal && light != null)
        {
            light.pointLightOuterRadius = 12;
            animator.SetTrigger("onfire");
            player.GetComponent<Health>().Heal(heal);
            _canHeal = false;
        }
    }
}
