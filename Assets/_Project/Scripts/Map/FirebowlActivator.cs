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

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (heroLayers == (heroLayers | 1 << other.gameObject.layer))
        {
            if (light != null)
            {
                light.pointLightOuterRadius = 10;
                animator.SetTrigger("onfire");
                player.GetComponent<Health>().Heal(2);
            }
                
        }
    }
}
