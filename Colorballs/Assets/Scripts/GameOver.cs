using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private void OnEnable()
    {
        BallCounter.ActionGameOver += SetupFinishPanel;
    }
    private void OnDisable()
    {
        BallCounter.ActionGameOver -= SetupFinishPanel;
    }
    private void SetupFinishPanel()
    {
        _panel.SetActive(true);
    }
}
