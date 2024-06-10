using UnityEngine;
using System;

public class PieceMatch : MonoBehaviour
{
    public static Action ActionSetupBall, ActionDeleteBall;
    public PieceType pieceType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BallSameFinder>())
        {
            pieceType = collision.GetComponent<BallSameFinder>().pieceType;
            collision.gameObject.transform.SetParent(transform, true);
            ActionSetupBall?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BallSameFinder>())
        {
            pieceType = PieceType.NoColor;
            ActionDeleteBall?.Invoke();
        }
    }
}
