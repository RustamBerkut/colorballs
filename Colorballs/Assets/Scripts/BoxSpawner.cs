using System.Collections.Generic;
using UnityEngine;
using System;

public class BoxSpawner : MonoBehaviour
{
    public static Action ActionMatch;
    public static Action<int> ActionBallCountSetup;
    public static Action ActionCheckArray;

    [Header("Введите количество столбцов")]
    [SerializeField] private byte _ballCount = 3;
    [SerializeField] private GameObject _floorSR;
    [SerializeField] private List<GameObject> _balls;
    [SerializeField] private GameObject _piece;

    private List<GameObject> horizontalPieces;
    private float _floorHeight;
    private GameObject[,] _pieces;

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
        ActionBallCountSetup?.Invoke(_ballCount * _ballCount);
        _floorHeight = _floorSR.GetComponent<Transform>().lossyScale.y;
        _pieces = new GameObject[_ballCount, _ballCount];
        InvokeRepeating(nameof(GetAllMatch), 1f, 1f);
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
        OnGridSpawner(startX, count, value);
        OnStartBallsSpawner(startX, count);
    }

    private void OnGridSpawner(float distance, float difference, float size)
    {
        float width = distance;
        float height = size;
        float diff = difference;
        height /= 2;
        for (int i = 0; i < _ballCount; i++)
        {
            for (int j = 0; j < _ballCount; j++)
            {
                GameObject go = Instantiate(_piece,
                                transform.position + new Vector3(width, height, 0),
                                transform.rotation);
                go.GetComponent<Transform>().localScale = new Vector3(size / 3, size / 3, 0);
                width += diff;
                _pieces[i, j] = go;
            }
            width = distance;
            height += size;
        }
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
    private void GetAllMatch()
    {
        GetHorizontalMatchBall();
        GetVerticalMatchBall();
        GetCrossMatchBall();
    }
    private void GetHorizontalMatchBall()
    {
        for (int j = 0; j < _ballCount; j++)
        {
            PieceType pieceType = _pieces[j, 0].GetComponent<PieceMatch>().pieceType;
            if (pieceType == PieceType.NoColor) return;
            GameObject go = _pieces[j, 0].GetComponentInChildren<BallSameFinder>().gameObject;
            horizontalPieces.Clear();
            horizontalPieces.Add(go);
            for (int i = 1; i < _ballCount; i++)
            {
                PieceType _pieceType = _pieces[j, i].GetComponent<PieceMatch>().pieceType;
                if (_pieceType == pieceType && _pieceType != PieceType.NoColor)
                {
                    go = _pieces[j, i].GetComponentInChildren<BallSameFinder>().gameObject;
                    horizontalPieces.Add(go);
                    if (horizontalPieces.Count >= 3)
                    {
                        for (int k = 0; k < horizontalPieces.Count; k++)
                        {
                            Destroy(horizontalPieces[k]);
                        }
                        horizontalPieces.Clear();
                        InMatchAction();
                    }
                }
            }
        }
    }
    private void GetVerticalMatchBall()
    {
        for (int j = 0; j < _ballCount; j++)
        {
            PieceType pieceType = _pieces[0, j].GetComponent<PieceMatch>().pieceType;
            if (pieceType == PieceType.NoColor) return;
            GameObject go = _pieces[0, j].GetComponentInChildren<BallSameFinder>().gameObject;
            horizontalPieces.Clear();
            horizontalPieces.Add(go);
            for (int i = 1; i < _ballCount; i++)
            {
                PieceType _pieceType = _pieces[i, j].GetComponent<PieceMatch>().pieceType;
                if (_pieceType == pieceType && _pieceType != PieceType.NoColor)
                {
                    go = _pieces[i, j].GetComponentInChildren<BallSameFinder>().gameObject;
                    horizontalPieces.Add(go);
                    if (horizontalPieces.Count >= 3)
                    {
                        for (int k = 0; k < horizontalPieces.Count; k++)
                        {
                            Destroy(horizontalPieces[k]);
                        }
                        horizontalPieces.Clear();
                        InMatchAction();
                    }
                }
            }
        }
    }
    private void GetCrossMatchBall()
    {
        PieceType pieceType = _pieces[0, 0].GetComponent<PieceMatch>().pieceType;
        if (pieceType == PieceType.NoColor) return;
        GameObject go = _pieces[0, 0].GetComponentInChildren<BallSameFinder>().gameObject;
        horizontalPieces.Clear();
        horizontalPieces.Add(go);

        for (int j = 1; j < _ballCount; j++)
        {
            PieceType _pieceType = _pieces[j, j].GetComponent<PieceMatch>().pieceType;
            if (_pieceType == pieceType && _pieceType != PieceType.NoColor)
            {
                go = _pieces[j, j].GetComponentInChildren<BallSameFinder>().gameObject;
                horizontalPieces.Add(go);
                if (horizontalPieces.Count >= 3)
                {
                    for (int k = 0; k < horizontalPieces.Count; k++)
                    {
                        Destroy(horizontalPieces[k]);
                    }
                    horizontalPieces.Clear();
                    InMatchAction();
                }
            }
        }
        pieceType = _pieces[_ballCount -1, 0].GetComponent<PieceMatch>().pieceType;
        if (pieceType == PieceType.NoColor) return;
        go = _pieces[_ballCount - 1, 0].GetComponentInChildren<BallSameFinder>().gameObject;
        horizontalPieces.Clear();
        horizontalPieces.Add(go);
        int i = 1;
        for (int j = _ballCount - 2; j >= 0; j--)
        {
            PieceType _pieceType = _pieces[j, i].GetComponent<PieceMatch>().pieceType;
            if (_pieceType == pieceType && _pieceType != PieceType.NoColor)
            {
                go = _pieces[j, j].GetComponentInChildren<BallSameFinder>().gameObject;
                horizontalPieces.Add(go);
                if (horizontalPieces.Count >= 3)
                {
                    for (int k = 0; k < horizontalPieces.Count; k++)
                    {
                        Destroy(horizontalPieces[k]);
                    }
                    horizontalPieces.Clear();
                    InMatchAction();
                }
            }
            i++;
        }
        ActionCheckArray?.Invoke();
    }
    private void InMatchAction()
    {
        ActionMatch?.Invoke();
    }
}