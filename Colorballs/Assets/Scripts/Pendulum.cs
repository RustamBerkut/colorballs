using UnityEngine;
using UnityEngine.UIElements;

public class Pendulum : MonoBehaviour
{
    [SerializeField] private float _maxAngleDeflection = 30.0f;
    [SerializeField] private float _speedOfPendulum = 1.0f;

    private void OnEnable()
    {
        BallCounter.ActionGameOver += OnFinishDestroy;
    }
    private void OnDisable()
    {
        BallCounter.ActionGameOver -= OnFinishDestroy;
    }
    private void FixedUpdate()
    {
        float angle = _maxAngleDeflection * Mathf.Sin(Time.time * _speedOfPendulum);
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
    private void OnFinishDestroy()
    {
        Destroy(gameObject);
    }
}
