using System;

public class ScoreManager : SingletonMonoBehavior<ScoreManager>
{
    #region Properties

    public int Score { get; private set; }

    #endregion


    #region Events

    public event Action<int> OnScoreChange;

    #endregion


    #region Pubic methods

    public void ChangeScore(int score)
    {
        Score += score;
        OnScoreChange?.Invoke(Score);
    }

    #endregion
}