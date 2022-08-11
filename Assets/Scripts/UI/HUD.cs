using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    #region Variables

    [Header("Values")]
    [SerializeField] public int NumOfHearts;
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _scoreLabel;
    [SerializeField] public Image[] hearts;
    [SerializeField] public Sprite FullHeart;
    [SerializeField] public Sprite EmptyHeart;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        ScoreManager.Instance.OnScoreChange += ScoreChanged;

        ScoreChanged(ScoreManager.Instance.Score);
    }

    private void Update()
    {
        int healthPoints = GameManager.Instance.CurrentHp;
        if (healthPoints > NumOfHearts)
        {
            healthPoints = NumOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = i < Mathf.RoundToInt(healthPoints) ? FullHeart : EmptyHeart;

            hearts[i].enabled = i < NumOfHearts;

            if (healthPoints > 0)
                continue;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnDestroy()
    {
        ScoreManager.Instance.OnScoreChange -= ScoreChanged;
    }

    #endregion


    #region Private methods

    private void ScoreChanged(int score)
    {
        _scoreLabel.text = $"Score: {ScoreManager.Instance.Score}";
    }

    #endregion
}