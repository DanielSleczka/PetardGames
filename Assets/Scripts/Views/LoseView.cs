using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoseView : BaseView
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private TextMeshProUGUI lastGamePointsValue;


    public void ShowLastPoints(float value)
    {
        lastGamePointsValue.text = $"{value}";
    }

    public void OnRestartGameButtonClicked_AddListener(UnityAction listener)
    {
        restartButton.onClick.AddListener(listener);
    }

    public void OnRestartGameButtonClicked_RemoveListener(UnityAction listener)
    {
        restartButton.onClick.RemoveListener(listener);
    }

    public void OnExitButtonClicked_AddListener(UnityAction listener)
    {
        exitButton.onClick.AddListener(listener);
    }

    public void OnExitButtonClicked_RemoveListener(UnityAction listener)
    {
        exitButton.onClick.RemoveListener(listener);
    }
}
