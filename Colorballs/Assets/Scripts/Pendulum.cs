using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField] private float MaxAngleDeflection = 30.0f;
    [SerializeField] private float SpeedOfPendulum = 1.0f;

    
    private void FixedUpdate()
    {
        float angle = MaxAngleDeflection * Mathf.Sin(Time.time * SpeedOfPendulum);
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
