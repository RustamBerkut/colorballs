using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField] private float _maxAngleDeflection = 30.0f;
    [SerializeField] private float _speedOfPendulum = 1.0f;

    private void FixedUpdate()
    {
        float angle = _maxAngleDeflection * Mathf.Sin(Time.time * _speedOfPendulum);
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
