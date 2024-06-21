using UnityEngine;

public enum PieceType
{
    RED,
    BLUE,
    GREEN,
    NoColor
};

public class BallSameFinder : MonoBehaviour
{
    public PieceType pieceType;
    [SerializeField] private ParticleSystem _particleSystem;

    private void OnDisable()
    {
        if (_particleSystem != null)
        {
            Instantiate(_particleSystem, transform.position, transform.rotation);
        }
    }
    private void OnDestroy()
    {
        
    }
}
