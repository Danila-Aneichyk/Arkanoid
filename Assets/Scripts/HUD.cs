using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreLabel;


    #region Unity lifecycle

    private void Update()
    {
        SetScoreLabel();
    }

    #endregion


    #region Private methods

    private void SetScoreLabel()
    {
        _scoreLabel.text = $"Score - {ScoreManager.Instance.Score}";
    }

    #endregion
}