using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField] private LayerMask heroLayers;
    [SerializeField] private GameManagerProxy proxy;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (heroLayers == (heroLayers | 1 << other.gameObject.layer))
            proxy.NextLevel();
    }
}
