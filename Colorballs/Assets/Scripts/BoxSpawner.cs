using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Unity.VisualScripting;

public class BoxSpawner : MonoBehaviour
{
    [Header("Введите количество столбцов")]
    [SerializeField] private byte _ballCount = 3;
    [SerializeField] private GameObject _floorSR;

    private float _floorHeight;

    private void OnEnable()
    {
        BallSpawner.ActionOnBallSpawn += OnBoxSpawner;
    }
    private void OnDisable()
    {
        BallSpawner.ActionOnBallSpawn -= OnBoxSpawner;
    }
    private void Start()
    {
        _floorHeight = _floorSR.GetComponent<Transform>().lossyScale.y;
    }
    private void OnBoxSpawner(float value)
    {
        float width = value;
        width = width * _ballCount + _floorHeight * (_ballCount + 1);

        GameObject floor = Instantiate(_floorSR, transform.position, transform.rotation);
        floor.GetComponent<Transform>().localScale = new Vector3(width, _floorHeight, 0);
    
        float count = width / (_ballCount);
        float x = count / 2;
        Debug.Log(x);
        for (int i = 0; i <= _ballCount; i++) 
        {
            GameObject wall = Instantiate(_floorSR, transform.position, Quaternion.Euler(0f,0f,90f));
            wall.GetComponent<Transform>().localScale = 
                new Vector3(value * _ballCount, _floorHeight, 0);

            wall.transform.parent = transform;
            wall.transform.position = transform.position + 
                new Vector3(x * i * 2, (value * _ballCount) / 2, 0);

            GameObject _wall = Instantiate(_floorSR, transform.position, Quaternion.Euler(0f, 0f, 90f));
            _wall.GetComponent<Transform>().localScale =
                new Vector3(value * _ballCount, _floorHeight, 0);

            _wall.transform.parent = transform;
            _wall.transform.position = transform.position +
                new Vector3(-x * i * 2, (value * _ballCount) / 2, 0);
        }
    }
}