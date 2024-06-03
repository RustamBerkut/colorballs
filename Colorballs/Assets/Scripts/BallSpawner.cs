using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public static Action<float> ActionOnBallSpawn;

    [SerializeField] private List<SpriteRenderer> _spriteRenderers;

    private float _textureWidth;
    private bool _isSpawn = true;   
   
    private void Start()
    {
        SetupBall();
        ActionOnBallSpawn?.Invoke(_textureWidth);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isSpawn)
        {
            RespawnBall();
        }
    }
    private void SetupBall()
    {
        _isSpawn = false;
        int capacity = _spriteRenderers.Capacity;
        int random = UnityEngine.Random.Range(0, capacity);
        SpriteRenderer sr = Instantiate(_spriteRenderers[random],
                        transform.position, transform.rotation);
        sr.transform.parent = transform;
        _textureWidth = sr.GetComponent<Transform>().lossyScale.x;
    }
    private void RespawnBall()
    {
        StartCoroutine(nameof(Respawn));
    }
    IEnumerator Respawn()
    {
        _isSpawn = true;
        yield return new WaitForSeconds(2);
        SetupBall();
    }
}
