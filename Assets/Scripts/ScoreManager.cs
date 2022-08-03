public class ScoreManager : SingletonMonoBehavior<ScoreManager>
{
    #region Properties

    public int Score { get; private set; }

    #endregion


    #region Pubic methods

    public void ChangeScore(int score)
    {
        Score += score;
    }

    #endregion
}