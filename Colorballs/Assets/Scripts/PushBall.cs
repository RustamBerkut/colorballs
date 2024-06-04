using System;
using Unity.VisualScripting;
using UnityEngine;

public class PushBall : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !transform.GetComponent<Rigidbody2D>())
        {
            OnPushBall();
        }
    }
    public void OnPushBall()
    {
        transform.parent = null;
        transform.AddComponent<Rigidbody2D>();
        Destroy(this);
    }
}
