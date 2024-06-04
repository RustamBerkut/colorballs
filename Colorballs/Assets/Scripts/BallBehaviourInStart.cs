using DG.Tweening;
using UnityEngine;

public enum DoType
{
    Shake,
    Move,
    Punch
}

public class BallBehaviourInStart : MonoBehaviour
{
    public Transform[] waypoints;
    public DoType DoType;

    private Tween _tween;
    private Vector3[] _path;

    private void Start()
    {
        _path = new Vector3[waypoints.Length];
        for (int i = 0; i < waypoints.Length; i++)
        {
            _path[i] = waypoints[i].position;
        }
        switch (DoType) 
        {
            case DoType.Shake: DoShake();
                break;
            case DoType.Move: DoMove();
                break;
            case DoType.Punch: DOPunch(); 
                break;  
        }
    }
    private void DoShake()
    {
        _tween = transform.DOShakePosition(10f, 2);
        _tween.SetLoops(-1);
    }
    private void DoMove()
    {
        _tween = transform.DOPath(_path, 3f);
        _tween.SetLoops(-1);
    }
    private void DOPunch()
    {
        _tween = transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 2);
        _tween.SetLoops(-1);
    }
    private void OnDisable()
    {
        _tween.Kill();
    }
}
