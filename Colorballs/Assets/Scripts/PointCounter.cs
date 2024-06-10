using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    private Text _textCounter;
    private int _counter = 0;

    private void OnEnable()
    {
        BoxSpawner.ActionMatch += OnCounterSetup;
    }
    private void OnDisable()
    {
        BoxSpawner.ActionMatch -= OnCounterSetup;
    }
    private void Start()
    {
        _textCounter = GetComponent<Text>();
    }
    private void OnCounterSetup()
    {
        _counter++;
        _textCounter.text = _counter.ToString();
    }
}
