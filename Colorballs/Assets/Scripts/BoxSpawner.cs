using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [Header("Введите количество столбцов")]
    [SerializeField] private byte _ballCount = 3;
    [SerializeField] private GameObject _floorSR;
    [SerializeField] private List<GameObject> _balls;

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
        float x = -width / 2;
        float startX = x + (count / 2);

        for (int i = 0; i <= _ballCount ; i++) 
        {
            GameObject wall = Instantiate(_floorSR, transform.position, Quaternion.Euler(0f,0f,90f));
            wall.GetComponent<Transform>().localScale = 
                new Vector3(value * _ballCount, _floorHeight, 0);

            wall.transform.parent = transform;
            wall.transform.position = transform.position + 
                new Vector3(x, (value * _ballCount) / 2, 0);
            x += count;
        }
        OnStartBallsSpawner(startX, count);
    }
    private void OnStartBallsSpawner(float distance, float difference)
    {
        float width = distance;
        float height = difference;
        float diff = difference;
        height /= 2;
        for (int i = 0; i < _ballCount - 1; i++)
        {
            for (int j = 0; j < _ballCount; j++)
            {
                int capacity = _balls.Capacity;
                int random = UnityEngine.Random.Range(0, capacity);
                GameObject go = Instantiate(_balls[random],
                                transform.position + new Vector3(width, height, 0), 
                                transform.rotation);
                go.AddComponent<Rigidbody2D>();
                width += diff;
            }
            width = distance;
            height += diff;
        }
    }
}