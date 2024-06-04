using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSameFinder : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private float _rayDistance;

    private void Start()
    {

    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        
        if (hit.collider != null)
        {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            float heightError = 10 - distance;
            Debug.Log(hit.collider.name);
        }
    }
    public void SetupRayFinder()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, 
                            transform.TransformDirection(Vector3.right), 
                            out hit, Mathf.Infinity, _layerMask))
        {
            Debug.DrawRay(transform.position, 
                          transform.TransformDirection(Vector3.right) * 
                          hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
    }
}
