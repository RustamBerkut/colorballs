using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> spriteRenderers;
    
    private void Start()
    {
        int capacity = spriteRenderers.Capacity;
        int random = UnityEngine.Random.Range(0, capacity - 1);
        SpriteRenderer sr = Instantiate(spriteRenderers[random], 
                        transform.position, transform.rotation);
        sr.transform.parent = transform;
    }
}
