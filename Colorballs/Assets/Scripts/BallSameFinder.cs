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
    [SerializeField] private ParticleSystem particleSystem;

    private void OnDestroy()
    {
        if (particleSystem != null) 
        {
            Instantiate(particleSystem, transform.position, transform.rotation);
        }
    }
}
