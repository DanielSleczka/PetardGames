using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoseView : BaseView
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private TextMeshProUGUI scoreValue;


    public void ShowScoreValue(float value)
    {
        scoreValue.text = $"{value}";
    }

    public void ChangeTextValueScale(Vector2 scale)
    {
        scoreValue.transform.DOScale(scale, .2f).OnComplete(() => scoreValue.transform.DOScale(Vector2.one, .2f));
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
