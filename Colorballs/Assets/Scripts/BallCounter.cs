using UnityEngine;
using System;

public class BallCounter : MonoBehaviour
{
    public static Action ActionGameOver;
    public int _ballCounter, _activeBalls;

    private void OnEnable()
    {
        BoxSpawner.ActionBallCountSetup += SetupSizeOfArrayBalls;
        BoxSpawner.ActionCheckArray += CheckArray;
        PieceMatch.ActionSetupBall += AddBallInCounter;
        PieceMatch.ActionDeleteBall += DeleteBallFromCounter;
    }
    private void OnDisable()
    {
        BoxSpawner.ActionBallCountSetup -= SetupSizeOfArrayBalls;
        BoxSpawner.ActionCheckArray -= CheckArray;
        PieceMatch.ActionSetupBall -= AddBallInCounter;
        PieceMatch.ActionDeleteBall -= DeleteBallFromCounter;
    }
    private void SetupSizeOfArrayBalls(int count)
    {
        _ballCounter = count;
    }
    private void AddBallInCounter()
    {
        _activeBalls++;
    }
    private void DeleteBallFromCounter()
    {
        _activeBalls--;
    }
    private void CheckArray()
    {
        if (_activeBalls == _ballCounter) 
        {
            ActionGameOver?.Invoke();
        }
    }
}
